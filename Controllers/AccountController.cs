﻿using LanchesJa.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LanchesJa.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel()
			{
				ReturnUrl = returnUrl,

			});
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{
			if (!ModelState.IsValid)
			{
				return View(loginVM);
			};

			var user = await _userManager.FindByNameAsync(loginVM.UserName);

			if (user != null)
			{
				//Aqui ele valida se o usuário que foi encontrado, contém a mesma senha que o usuário está passando na viewModel.
				var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

				if (result.Succeeded)
				{
					if (string.IsNullOrEmpty(loginVM.ReturnUrl))
					{
						return RedirectToAction("Index", "Home");
					}
					return Redirect(loginVM.ReturnUrl);
				}
			}
			ModelState.AddModelError("", "Falha ao realizar o login!");
			return View(loginVM);
		}

		
		public IActionResult Register()
		{
			return View();

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(LoginViewModel registerVM)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser { UserName = registerVM.UserName };

				var result = await _userManager.CreateAsync(user, registerVM.Password);

				if (result.Succeeded)
				{
					//await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Login", "Account");
				}
				else
				{
					ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
				}
			}
			return View(registerVM);

		}
	}
}

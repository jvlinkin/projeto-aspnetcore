using System.ComponentModel.DataAnnotations;

namespace LanchesJa.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Informe o nome")]
		[Display(Name ="Usuário")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Informe sua senha")]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }
	}
}

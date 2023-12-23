using System;
namespace Mango.web.Models
{
	public class ResponseDto
	{
		public Object?  Result { get; set; }
		public bool IsSuccess { get; set; } = true;
		public object Message { get; set; } = "";
	}
}


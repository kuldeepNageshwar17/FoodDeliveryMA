using System;
namespace Mango.Services.CouponAPI.Models.Dto
{
	public class ResponseDto
	{
		public Object?  Result { get; set; }
		public bool IsSuccess { get; set; } = true;
		public object Message { get; set; } = "";
	}
}


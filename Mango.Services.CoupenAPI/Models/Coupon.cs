using System;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models
{
	public class Coupon
	{
		[Key]
		public int  CuponId { get; set; }
		[Required] 
		public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
		public int MinAmount { get; set; }
		public DateTime LastUpdated { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}


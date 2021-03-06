﻿using System.ComponentModel.DataAnnotations;

namespace ApiClients.Cart.Common.DTO
{
    public sealed class XUpdateCartItemQuantityRequest
    {
        [Required]
        [Range(1, 50)]
        public int? Quantity { get; set; }
    }
}

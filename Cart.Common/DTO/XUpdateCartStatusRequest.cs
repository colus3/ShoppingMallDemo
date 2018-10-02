using System.ComponentModel.DataAnnotations;

namespace ApiClients.Cart.Common.DTO
{
    public sealed class XUpdateCartStatusRequest
    {
        [Required]
        public EXCartStatus? Status { get; set; }
    }
}

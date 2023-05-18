using Agricultural.Domain.Entity.Base;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class User : IdentityUser, ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public byte UserType { get; set; } // UserType
        public byte? State { get; set; } // State
        public bool? Active { get; set; } // Active

        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        // to product 
        public List<Product> Products { get; set; }

        // to  ProductEvaluaton
        public List<ProductEvaluaton> productEvaluatons { get; set; }

        // to ProviderEvaluation
        public List<ProviderEvaluation> providerEvaluations { get; set; }

        // to SP_User_Favourites
        public List<SP_User_Favourites> SP_User_Favourites { get; set; }

        // to Product_User_Favourites
        public List<Product_User_Favourites> product_User_Favourites { get; set; }

        public List<ServiceProvider> ServiceProviders { get; set; }

        public List<SP_Address> SP_Address { get; set; }
        public bool Status { get; set; }
         public List<Cart> Carts { get; set; }   
         public List<CartDetails> CartDetails { get; set; }      
        public List<Order> Orders { get; set; }   
         public List<OrderDetails> OrderDetails { get; set; }   

        public User()
        {
            Active = true;
            Status = false;
        }
    }
}

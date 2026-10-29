using ASPNET_SWAGA.Models;
using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using AutoMapper;

namespace ASPNET_SWAGA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Infoproduct, InfoproductDTO>();

            CreateMap<User, UserDTO>()
                .ForMember(d => d.Role, o => o.MapFrom(s => s.IdRolesNavigation));

            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.Info, o => o.MapFrom(s => s.IdInfoProductsNavigation))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.IdCategoriesNavigation));

            CreateMap<Cart, CartDTO>()
                .ForMember(d => d.User, o => o.MapFrom(s => s.IdUserNavigation))
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Cartitems));

            CreateMap<Cartitem, CartitemDTO>()
                .ForMember(d => d.Product, o => o.MapFrom(s => s.IdProductsNavigation));

            CreateMap<Order, OrderDTO>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Ordersitems));

            CreateMap<Ordersitem, OrdersitemDTO>()
                .ForMember(d => d.Product, o => o.MapFrom(s => s.IdProductsNavigation));

            CreateMap<Reservation, ReservationDTO>()
                .ForMember(d => d.User, o => o.MapFrom(s => s.IdUserNavigation))
                .ForMember(d => d.Product, o => o.MapFrom(s => s.IdProductsNavigation))
                .ForMember(d => d.IsActive, o => o.MapFrom(s => s.ReleasedAt == null));

            CreateMap<CreateRoleDTO, Role>();
            CreateMap<UpdateRoleDTO, Role>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<CreateInfoproductDTO, Infoproduct>();
            CreateMap<UpdateInfoproductDTO, Infoproduct>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<CreateCartDTO, Cart>();
            CreateMap<UpdateCartDTO, Cart>();
            CreateMap<CreateCartitemDTO, Cartitem>();
            CreateMap<UpdateCartitemDTO, Cartitem>();
            CreateMap<CreateOrderDTO, Order>();
            CreateMap<UpdateOrderDTO, Order>();
            CreateMap<CreateOrdersitemDTO, Ordersitem>();
            CreateMap<UpdateOrdersitemDTO, Ordersitem>();

            CreatePatchMap<PatchRoleDTO, Role>();
            CreatePatchMap<PatchCategoryDTO, Category>();
            CreatePatchMap<PatchInfoproductDTO, Infoproduct>();
            CreatePatchMap<PatchUserDTO, User>();
            CreatePatchMap<PatchProductDTO, Product>();
            CreatePatchMap<PatchCartDTO, Cart>();
            CreatePatchMap<PatchCartitemDTO, Cartitem>();
            CreatePatchMap<PatchOrderDTO, Order>();
            CreatePatchMap<PatchOrdersitemDTO, Ordersitem>();
        }

        private void CreatePatchMap<TPatch, TEntity>() =>
            CreateMap<TPatch, TEntity>()
                .ForAllMembers(o => o.Condition((src, dest, srcMember) => srcMember != null));
    }
}

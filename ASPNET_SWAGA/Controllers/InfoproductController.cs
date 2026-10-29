using ASPNET_SWAGA.Models.CreateDTO;
using ASPNET_SWAGA.Models.DTO;
using ASPNET_SWAGA.Models.PatchDTO;
using ASPNET_SWAGA.Models.UpdateDTO;
using ASPNET_SWAGA.Services;

namespace ASPNET_SWAGA.Controllers;

public class InfoproductController : CrudControllerBase<InfoproductDTO, CreateInfoproductDTO, UpdateInfoproductDTO, PatchInfoproductDTO>
{
    public InfoproductController(IInfoproductService service) : base(service)
    {
    }

    protected override int GetId(InfoproductDTO dto) => dto.InfoProductsId;
}

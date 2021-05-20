using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WsAutomatizacionCanjes.Class;
using WsAutomatizacionCanjes.Filters;
using Microsoft.AspNetCore.Mvc.Core;

namespace WsAutomatizacionCanjes.Controllers
{
    public class CanjesAPIController : ApiController
    {
        [HttpPost] //WS de Artículos Método POST
        [CacheControl(MaxAge = 4000)]
        [Route("api/CanjesAPI/ZRFC_VALIDATE_MATERIAL")]
        public IHttpActionResult postMateriales([System.Web.Http.FromBody] JObject value)
        {

            if (value == null) return BadRequest("Se esperaba un objeto json");
            dynamic json = value.ToObject<dynamic>();
            if (json.material == null || Convert.ToString(json.material) == "") return BadRequest("Se esperaba un material válido");
            CanjesGestor okielsaAPIGestor = new CanjesGestor();
            var amaterial = okielsaAPIGestor.validacion_material(json);
            return Ok(amaterial);
        }

        [HttpPost] //WS de Stock de Canjes Método POST
        [CacheControl(MaxAge = 4000)]
        [Route("api/CanjesAPI/ZRFC_GET_STOCK_FOR_CANJES")]
        public IHttpActionResult postStockForCanjes([System.Web.Http.FromBody] JObject value)
        {

            if (value == null) return BadRequest("Se esperaba un objeto json");
            dynamic json = value.ToObject<dynamic>();
            if (json.centro == null || Convert.ToString(json.centro) == "") return BadRequest("Se esperaba un centro válido");
            if (json.material == null || Convert.ToString(json.material) == "") return BadRequest("Se esperaba un material válido");
            if (json.cantidad == null || Convert.ToString(json.cantidad) == "") return BadRequest("Se esperaba una cantidad válida");
            if (json.unidad == null || Convert.ToString(json.unidad) == "") return BadRequest("Se esperaba una unidad válida");
            CanjesGestor okielsaAPIGestor = new CanjesGestor();
            var aStock = okielsaAPIGestor.stock_material(json);
            return Ok(aStock);
        }

        [HttpPost] //WS de Stock de Canjes Método POST
        [CacheControl(MaxAge = 4000)]
        [Route("api/CanjesAPI/ZRFC_VALIDATE_MATERIAL_INVOICE")]
        public IHttpActionResult postValidateMaterialInvoice([System.Web.Http.FromBody] JObject value)
        {

            if (value == null) return BadRequest("Se esperaba un objeto json");
            dynamic json = value.ToObject<dynamic>();
            if (json.sociedad == null || Convert.ToString(json.sociedad) == "") return BadRequest("Se esperaba una sociedad válida");
            if (json.cliente == null || Convert.ToString(json.cliente) == "") return BadRequest("Se esperaba un cliente válido");
            if (json.material == null || Convert.ToString(json.material) == "") return BadRequest("Se esperaba un material válido");
            if (json.meses == null || Convert.ToString(json.meses) == "") return BadRequest("Se esperaba un número de mes válido");
            CanjesGestor okielsaAPIGestor = new CanjesGestor();
            var aStock = okielsaAPIGestor.validate_material_invoice(json);
            return Ok(aStock);
        }

        [HttpPost] //WS de Stock de Canjes Método POST
        [CacheControl(MaxAge = 4000)]
        [Route("api/CanjesAPI/ZRFC_GOODS_MOVEMENT_CANJES")]
        public IHttpActionResult postGoods_Movement_Canjes([System.Web.Http.FromBody] JObject value)
        {

            if (value == null) return BadRequest("Se esperaba un objeto json");
            dynamic json = value.ToObject<dynamic>();
            if (json.documento == null || Convert.ToString(json.documento) == "") return BadRequest("Se esperaba un número de documento válido");
            if (json.proveedor == null || Convert.ToString(json.proveedor) == "") return BadRequest("Se esperaba un número de proveedor válido");
            if (json.receptor == null || Convert.ToString(json.receptor) == "") return BadRequest("Se esperaba un receptor válido");
            CanjesGestor okielsaAPIGestor = new CanjesGestor();
            var aMigo = okielsaAPIGestor.Consumo_MIGO(json);
            return Ok(aMigo);
        }
    }
}
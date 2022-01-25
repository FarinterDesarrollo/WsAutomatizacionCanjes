using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SAP.Middleware.Connector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WsAutomatizacionCanjes.ClassModels;

namespace WsAutomatizacionCanjes.Class
{
    public class CanjesGestor
    {
        // ************************* Sección Funciones y procedimientos ****************************
        private RfcDestination RfcDestination;

        public string validacion_material(dynamic obj)
        {
            string salida = "";
            try
            {
                string material = obj.material;

                while (material.Length < 18)
                {
                    material = "0" + material;
                }

                string destinationconfigname = HttpContext.Current.Application["destinationconfigname"] as string;
                salida = ZRFC_VALIDATE_MATERIAL(destinationconfigname, material);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return salida;
        }

        public string stock_material(dynamic obj)
        {
            DataSet tabla = new DataSet();
            string salida = "";
            try
            {
                string centro = obj.centro;
                string material = obj.material;
                decimal cantidad = obj.cantidad;
                string unidad = obj.unidad;

                while (material.Length < 18)
                {
                    material = "0" + material;
                }

                string destinationconfigname = HttpContext.Current.Application["destinationconfigname"] as string;
                tabla = ZRFC_GET_STOCK_FOR_CANJES(destinationconfigname, centro, material, cantidad, unidad);
                DataTable t1 = new DataTable(); DataTable t2 = new DataTable(); DataTable t3 = new DataTable();
                t1 = tabla.Tables[0]; t2 = tabla.Tables[1]; t3 = tabla.Tables[2];
                List<jsonrfcdevolucioneserror> json = new List<jsonrfcdevolucioneserror>();

                if (t1.Rows.Count > 0)
                {
                    for (int i = 0; i <= t1.Rows.Count - 1; i++)
                    {
                        json.Add(new jsonrfcdevolucioneserror
                        {
                            MATERIAL = t1.Rows[i]["MATERIAL"].ToString(),
                            CENTRO = t1.Rows[i]["CENTRO"].ToString(),
                            ALMACEN = t1.Rows[i]["ALMACEN"].ToString(),
                            LOTE = t1.Rows[i]["LOTE"].ToString(),
                            FECHA_CAD = t1.Rows[i]["FECHA_CAD"].ToString(),
                            CANTIDAD = Convert.ToDecimal(t1.Rows[i]["CANTIDAD"].ToString()),
                            UNIDAD = t1.Rows[i]["UNIDAD"].ToString(),
                            TYPE = "",
                            MESSAGE = ""
                        });
                    }
                }

                if (t2.Rows.Count > 0)
                {
                    for (int i = 0; i <= t2.Rows.Count - 1; i++)
                    {
                        json.Add(new jsonrfcdevolucioneserror
                        {
                            MATERIAL = t2.Rows[i]["MATERIAL"].ToString(),
                            CENTRO = t2.Rows[i]["CENTRO"].ToString(),
                            ALMACEN = t2.Rows[i]["ALMACEN"].ToString(),
                            LOTE = t2.Rows[i]["LOTE"].ToString(),
                            FECHA_CAD = t2.Rows[i]["FECHA_CAD"].ToString(),
                            CANTIDAD = Convert.ToDecimal(t2.Rows[i]["CANTIDAD"].ToString()),
                            UNIDAD = t2.Rows[i]["UNIDAD"].ToString(),
                            TYPE = "",
                            MESSAGE = ""
                        });
                    }
                }

                if (t3.Rows.Count > 0)
                {
                    for (int i = 0; i <= t3.Rows.Count - 1; i++)
                    {
                        json.Add(new jsonrfcdevolucioneserror
                        {
                            TYPE = t3.Rows[i]["TYPE"].ToString(),
                            MESSAGE = t3.Rows[i]["MESSAGE"].ToString()
                        });
                    }
                }

                salida = JsonConvert.SerializeObject(json).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return salida;
        }
        public string stock_material2(dynamic obj)
        {
            DataSet tabla = new DataSet();
            string salida = "";
            try
            {
                string centro = obj.centro;
                int documento = obj.documento;

                string destinationconfigname = HttpContext.Current.Application["destinationconfigname"] as string;
                tabla = ZRFC_GET_STOCK_FOR_CANJES2(destinationconfigname, centro, documento);
                DataTable t1 = new DataTable(); DataTable t2 = new DataTable(); DataTable t3 = new DataTable();
                t1 = tabla.Tables[0]; t2 = tabla.Tables[1]; t3 = tabla.Tables[2];
                List<jsonrfcdevolucioneserror> json = new List<jsonrfcdevolucioneserror>();

                if (t1.Rows.Count > 0)
                {
                    for (int i = 0; i <= t1.Rows.Count - 1; i++)
                    {
                        json.Add(new jsonrfcdevolucioneserror
                        {
                            MATERIAL = t1.Rows[i]["MATERIAL"].ToString(),
                            CENTRO = t1.Rows[i]["CENTRO"].ToString(),
                            ALMACEN = t1.Rows[i]["ALMACEN"].ToString(),
                            LOTE = t1.Rows[i]["LOTE"].ToString(),
                            FECHA_CAD = t1.Rows[i]["FECHA_CAD"].ToString(),
                            CANTIDAD = Convert.ToDecimal(t1.Rows[i]["CANTIDAD"].ToString()),
                            UNIDAD = t1.Rows[i]["UNIDAD"].ToString(),
                            TYPE = "",
                            MESSAGE = ""
                        });
                    }
                }

                if (t2.Rows.Count > 0)
                {
                    for (int i = 0; i <= t2.Rows.Count - 1; i++)
                    {
                        json.Add(new jsonrfcdevolucioneserror
                        {
                            MATERIAL = t2.Rows[i]["MATERIAL"].ToString(),
                            CENTRO = t2.Rows[i]["CENTRO"].ToString(),
                            ALMACEN = t2.Rows[i]["ALMACEN"].ToString(),
                            LOTE = t2.Rows[i]["LOTE"].ToString(),
                            FECHA_CAD = t2.Rows[i]["FECHA_CAD"].ToString(),
                            CANTIDAD = Convert.ToDecimal(t2.Rows[i]["CANTIDAD"].ToString()),
                            UNIDAD = t2.Rows[i]["UNIDAD"].ToString(),
                            TYPE = "",
                            MESSAGE = ""
                        });
                    }
                }

                if (t3.Rows.Count > 0)
                {
                    for (int i = 0; i <= t3.Rows.Count - 1; i++)
                    {
                        json.Add(new jsonrfcdevolucioneserror
                        {
                            TYPE = t3.Rows[i]["TYPE"].ToString(),
                            MESSAGE = t3.Rows[i]["MESSAGE"].ToString(),
                            ID = t3.Rows[i]["ID"].ToString(),
                            NUMBER = t3.Rows[i]["NUMBER"].ToString(),
                            MESSAGE_V1 = t3.Rows[i]["MESSAGE_V1"].ToString(),
                            MESSAGE_V2 = t3.Rows[i]["MESSAGE_V2"].ToString()
                        });
                    }
                }

                salida = JsonConvert.SerializeObject(json).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return salida;
        }
        public class jsonrfcdevolucioneserror
        {
            public string MATERIAL { get; set; }
            public string CENTRO { get; set; }
            public string ALMACEN { get; set; }
            public string LOTE { get; set; }
            public string FECHA_CAD { get; set; }
            public decimal CANTIDAD { get; set; }
            public string UNIDAD { get; set; }
            public string TYPE { get; set; }
            public string MESSAGE { get; set; }
            public string ID { get; set; }
            public string NUMBER { get; set; }
            public string MESSAGE_V1 { get; set; }
            public string MESSAGE_V2 { get; set; }

        }
        public string validate_material_invoice(dynamic obj)
        {
            string salida = "";
            try
            {
                string sociedad = obj.sociedad;
                string cliente = obj.cliente;
                string material = obj.material;
                string meses = obj.meses;

                while (material.Length < 18)
                {
                    material = "0" + material;
                }

                string destinationconfigname = HttpContext.Current.Application["destinationconfigname"] as string;
                salida = ZRFC_VALIDATE_MATERIAL_INVOICE(destinationconfigname, sociedad, cliente, material, meses);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return salida;
        }
        public object parametrosRFC
        {
            get; set;
        }
        public string Consumo_MIGO(dynamic obj)
        {
            string salida = "";
            DataTable tabla = new DataTable();
            try
            {
                int documento = obj.documento;
                string proveedor = obj.proveedor;
                string receptor = obj.receptor;

                string destinationconfigname = HttpContext.Current.Application["destinationconfigname"] as string;
                tabla = ZRFC_GOODS_MOVEMENT_CANJES(destinationconfigname, documento, proveedor, receptor);
                List<Detalle_Migo> json = new List<Detalle_Migo>();

                for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                {
                    json.Add(new Detalle_Migo
                    {
                        ep_material_document = Convert.ToString(tabla.Rows[i]["EP_MATERIAL_DOCUMENT"]),
                        ep_document_year = Convert.ToString(tabla.Rows[i]["EP_DOCUMENT_YEAR"]),
                        type = Convert.ToString(tabla.Rows[i]["TYPE"]),
                        message = Convert.ToString(tabla.Rows[i]["MESSAGE"]),
                        id = Convert.ToString(tabla.Rows[i]["ID"]),
                        number = Convert.ToString(tabla.Rows[i]["NUMBER"])
                    });
                }

                salida = JsonConvert.SerializeObject(json).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return salida;
        }

        public class Detalle_Migo
        {
            public string ep_material_document { get; set; }
            public string ep_document_year { get; set; }
            public string type { get; set; }
            public string message { get; set; }
            public string id { get; set; }
            public string number { get; set; }

        }

        public List<Datos_Doc_Material> datos_doc_material(dynamic obj) 
        {
            List<Datos_Doc_Material> salida = new List<Datos_Doc_Material>();
            DataTable tabla = new DataTable();

            try
            {
                string documento = obj.documento;
                string year = obj.year;
                string destinationconfigname = HttpContext.Current.Application["destinationconfigname"] as string;
                tabla = ZRFC_GET_DATOS_DOC_MATERIAL(destinationconfigname, documento, year);

                if (tabla.Rows.Count > 0)
                {
                    for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                    {

                        if(tabla.Rows[i]["E_MENSAJE"].ToString() != "") 
                        {
                            salida.Add(new Datos_Doc_Material
                            {
                                e_mensaje = tabla.Rows[i]["E_MENSAJE"].ToString()
                            });
                            return salida;
                        }
                        else 
                        {
                            salida.Add(new Datos_Doc_Material
                            {
                                e_mensaje = tabla.Rows[i]["E_MENSAJE"].ToString(),
                                num_pedido = tabla.Rows[i]["NUM_PEDIDO"].ToString(),
                                num_ref_salida = tabla.Rows[i]["NUM_REF_SALIDA"].ToString(),
                                gui_remision = tabla.Rows[i]["GUI_REMISION"].ToString(),
                                cai = tabla.Rows[i]["CAI"].ToString(),
                                valor_neto = Convert.ToDecimal(tabla.Rows[i]["VALOR_NETO"].ToString()),
                                doc_anulacion = tabla.Rows[i]["DOC_ANULACION"].ToString(),
                                moneda = tabla.Rows[i]["MONEDA"].ToString(),
                                proveedor = tabla.Rows[i]["PROVEEDOR"].ToString(),
                                almacen = tabla.Rows[i]["ALMACEN"].ToString(),
                                org_compras = tabla.Rows[i]["ORG_COMPRAS"].ToString()
                            });
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                List<Datos_Doc_Material> error = new List<Datos_Doc_Material>();
                error.Add(new Datos_Doc_Material
                {
                    e_mensaje = ex.Message
                });
                return error;
            }
            return salida;
        }

        public class Mensaje_Error 
        { 
            public string mensaje { get; set; }
        }
        public class Datos_Doc_Material
        {
            public string e_mensaje { get; set; }
            public string num_pedido { get; set; }
            public string num_ref_salida { get; set; }
            public string gui_remision { get; set; }
            public string cai { get; set; }
            public decimal valor_neto { get; set; }
            public string doc_anulacion { get; set; }
            public string moneda { get; set; }
            public string proveedor { get; set; }
            public string almacen { get; set; }
            public string org_compras { get; set; }
        }

        public DataTable ConvertToDotNetTables(IRfcTable RFCTable)
        {
            DataTable dtTable = new DataTable();

            //crear tabla
            for (int item = 0; item < RFCTable.ElementCount; item++)
            {
                RfcElementMetadata metadata = RFCTable.GetElementMetadata(item);
                dtTable.Columns.Add(metadata.Name);
            }
            foreach (IRfcStructure row in RFCTable)
            {
                DataRow dr = dtTable.NewRow();
                for (int item = 0; item < RFCTable.ElementCount; item++)
                {
                    RfcElementMetadata metadata = RFCTable.GetElementMetadata(item);
                    if (metadata.DataType == RfcDataType.BCD && metadata.Name == "ABC")
                    {
                        dr[item] = row.GetInt(metadata.Name);
                    }

                    else if (metadata.DataType != RfcDataType.TABLE)
                    {
                        dr[item] = row.GetString(metadata.Name);
                    }
                }
                dtTable.Rows.Add(dr);
            }
            return dtTable;
        }

        public DataTable Convert_table_sap_to_DataTable(IRfcTable sapTable)
        {
            DataTable table_return = new DataTable();
            for (int liElement = 0; liElement <= sapTable.ElementCount - 1; liElement++)
            {
                RfcElementMetadata metadata = sapTable.GetElementMetadata(liElement);
                table_return.Columns.Add(metadata.Name, GetDataType(metadata.DataType));

            }
            //Transferir filas de tabla SAP a DataTable
            //        foreach (IRfcStructure row in rfcfunction.GetTable("ET_ITEMS_OUT"))
            foreach (IRfcStructure row in sapTable)
            {
                DataRow ldr = table_return.NewRow();
                for (int liElement = 0; liElement <= sapTable.ElementCount - 1; liElement++)
                {
                    RfcElementMetadata metadata = sapTable.GetElementMetadata(liElement);

                    if (metadata.DataType == RfcDataType.DATE)
                    {
                        ldr[metadata.Name] = row.GetString(metadata.Name).Substring(0, 4) +
                                             row.GetString(metadata.Name).Substring(5, 2) +
                                             row.GetString(metadata.Name).Substring(8, 2);
                    }
                    else if (metadata.DataType == RfcDataType.BCD)
                    {
                        ldr[metadata.Name] = row.GetDecimal(metadata.Name);
                    }
                    else if (metadata.DataType == RfcDataType.CHAR)
                    {
                        ldr[metadata.Name] = row.GetString(metadata.Name);
                    }
                    else if (metadata.DataType == RfcDataType.STRING)
                    {
                        ldr[metadata.Name] = row.GetString(metadata.Name);
                    }
                    else if (metadata.DataType == RfcDataType.INT2)
                    {
                        ldr[metadata.Name] = row.GetInt(metadata.Name);
                    }
                    else if (metadata.DataType == RfcDataType.INT4)
                    {
                        ldr[metadata.Name] = row.GetInt(metadata.Name);
                    }
                    else if (metadata.DataType == RfcDataType.FLOAT)
                    {
                        ldr[metadata.Name] = row.GetDouble(metadata.Name);
                    }
                    else if (metadata.DataType == RfcDataType.TABLE)
                    {
                        IRfcTable table = row.GetTable(metadata.Name);
                        DataTable dt_in_row = Convert_table_sap_to_DataTable(table);
                        ldr[metadata.Name] = dt_in_row;
                    }
                    else if (metadata.DataType == RfcDataType.STRUCTURE)
                    {
                        IRfcStructure structure = row.GetStructure(metadata.Name);
                        ldr[metadata.Name] = structure;

                    }
                    else
                    {
                        ldr[metadata.Name] = row.GetString(metadata.Name);
                    }

                }
                table_return.Rows.Add(ldr);
            }
            return table_return;
        }
        public DataTable ConvertirEstructura(IRfcStructure rfcestructura) //convertir  RFCStructure a un datatable
        {
            DataTable rowTable = new DataTable();
            for (int i = 0; i <= rfcestructura.ElementCount - 1; i++)
            {
                rowTable.Columns.Add(rfcestructura.GetElementMetadata(i).Name);
            }

            DataRow row = rowTable.NewRow();

            for (int j = 0; j <= rfcestructura.ElementCount - 1; j++)
            {
                row[j] = rfcestructura.GetValue(j);
            }
            rowTable.Rows.Add(row);
            return rowTable;
        }
        public Type GetDataType(RfcDataType rfcDataType)
        {
            switch (rfcDataType)
            {
                case RfcDataType.DATE:
                    return typeof(string);
                case RfcDataType.CHAR:
                    return typeof(string);
                case RfcDataType.STRING:
                    return typeof(string);
                case RfcDataType.BCD:
                    return typeof(Decimal);
                case RfcDataType.NUM:
                    return typeof(String);
                case RfcDataType.INT1:
                    return typeof(int);
                case RfcDataType.INT2:
                    return typeof(int);
                case RfcDataType.INT4:
                    return typeof(int);
                case RfcDataType.FLOAT:
                    return typeof(Double);
                case RfcDataType.STRUCTURE:
                    return typeof(DataRow);
                case RfcDataType.TABLE:
                    return typeof(DataTable);
                default:
                    return typeof(String);

            }
        }

        // ************************* Fin Funciones y Procedimientos ****************************

        // ************************* Sección RFC ****************************
        private string ZRFC_VALIDATE_MATERIAL(string destinationname, string material)
        {
            string EP_MENSAJE = "";
            try
            {
                if (RfcDestination == null)
                {
                    RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                }
                RfcRepository rfcRepository = RfcDestination.Repository;
                IRfcFunction rfcfunction = rfcRepository.CreateFunction("ZRFC_VALIDATE_MATERIAL");
                rfcfunction.SetValue("IP_MATERIAL", material);
                rfcfunction.Invoke(RfcDestination);
                EP_MENSAJE = rfcfunction.GetString("EP_RESPONSE");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return EP_MENSAJE;
        }

        private DataSet ZRFC_GET_STOCK_FOR_CANJES(string destinationname, string centro, string material, decimal cantidad, string unidad)
        {
            DataSet stock = new DataSet();
            try
            {
                if (RfcDestination == null)
                {
                    RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                }

                DataTable tabla = new DataTable();
                tabla.Columns.Add("MATERIAL");
                tabla.Columns.Add("CANTIDAD");
                tabla.Columns.Add("UNIDAD");
                tabla.Rows.Add(material, cantidad, unidad);

                RfcRepository rfcRepository = RfcDestination.Repository;
                IRfcFunction rfcfunction = rfcRepository.CreateFunction("ZRFC_GET_STOCK_FOR_CANJES");
                IRfcTable IT_MATERIALES = rfcfunction.GetTable("IT_MATERIALES");
                for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                {
                    IT_MATERIALES.Append();
                    IT_MATERIALES.SetValue("MATERIAL", tabla.Rows[i]["MATERIAL"]);
                    IT_MATERIALES.SetValue("CANTIDAD", tabla.Rows[i]["CANTIDAD"]);
                    IT_MATERIALES.SetValue("UNIDAD", tabla.Rows[i]["UNIDAD"]);
                }

                rfcfunction.SetValue("IP_CENTRO", centro);
                rfcfunction.Invoke(RfcDestination);
                stock.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_LOTES_GOOD")));
                stock.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_LOTES_APV")));
                stock.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_MESSAGES")));
                //EP_MENSAJE = rfcfunction.GetString("ET_MESSAGES");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return stock;
        }
        private DataSet ZRFC_GET_STOCK_FOR_CANJES2(string destinationname, string centro, int documento)
        {
            Sql osql = new Sql();
            Globales oglobales = new Globales();
            DataSet stock = new DataSet();
            try
            {
                if (RfcDestination == null)
                {
                    RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                }

                DataTable tabla = new DataTable();
                oglobales.query = "select Cod_Prod_SAP,sum(Cantidad_Enviar) AS Cantidad_Enviar,UNIDAD " +
                                  "from TBL_DetalleSAP where Documento=" + documento + " and Mensaje3='CANJE' group by Cod_Prod_SAP,UNIDAD";
                tabla = osql.ddt(oglobales.query, Conexion.AutCanjes);

                RfcRepository rfcRepository = RfcDestination.Repository;
                IRfcFunction rfcfunction = rfcRepository.CreateFunction("ZRFC_GET_STOCK_FOR_CANJES");
                IRfcTable IT_MATERIALES = rfcfunction.GetTable("IT_MATERIALES");
                for (int i = 0; i <= tabla.Rows.Count - 1; i++)
                {
                    IT_MATERIALES.Append();
                    IT_MATERIALES.SetValue("MATERIAL", tabla.Rows[i]["Cod_Prod_SAP"]);
                    IT_MATERIALES.SetValue("CANTIDAD", tabla.Rows[i]["Cantidad_Enviar"]);
                    IT_MATERIALES.SetValue("UNIDAD", tabla.Rows[i]["UNIDAD"]);
                }

                rfcfunction.SetValue("IP_CENTRO", centro);
                rfcfunction.Invoke(RfcDestination);
                stock.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_LOTES_GOOD")));
                stock.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_LOTES_APV")));
                stock.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_MESSAGES")));
                //EP_MENSAJE = rfcfunction.GetString("ET_MESSAGES");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return stock;
        }
        private string ZRFC_VALIDATE_MATERIAL_INVOICE(string destinationname, string sociedad, string cliente, string material, string meses)
        {
            string EP_MENSAJE = "";
            try
            {
                if (RfcDestination == null)
                {
                    RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                }
                RfcRepository rfcRepository = RfcDestination.Repository;
                IRfcFunction rfcfunction = rfcRepository.CreateFunction("ZRFC_VALIDATE_MATERIAL_INVOICE");
                rfcfunction.SetValue("IP_SOCIEDAD", sociedad);
                rfcfunction.SetValue("IP_CLIENTE", cliente);
                rfcfunction.SetValue("IP_MATERIAL", material);
                rfcfunction.SetValue("IP_MESES", meses);
                rfcfunction.Invoke(RfcDestination);
                EP_MENSAJE = rfcfunction.GetString("EP_RESPONSE");
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return EP_MENSAJE;
        }

        public DataTable ZRFC_GOODS_MOVEMENT_CANJES(string destinationname, int documento, string proveedor, string receptor)
        {
            Sql osql = new Sql();
            Globales oglobales = new Globales();
            DataSet ET_RETURN = new DataSet();
            DataTable TABLA_SALIDA = new DataTable();
            string EP_MATERIAL_DOCUMENT = "";
            string EP_DOCUMENT_YEAR = "";
            try
            {
                if (RfcDestination == null)
                {
                    RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                }
                RfcRepository rfcRepository = RfcDestination.Repository;

                //1 - Área de consultas
                oglobales.query = "select Observaciones from TBL_EncabezadoSAP where Documento=" + documento;
                string header = osql.get(oglobales.query, Conexion.AutCanjes);
                oglobales.query = "select FORMAT(Fecha_Autorizacion,'yyyMMdd') as Fecha_Autorizacion from TBL_EncabezadoSAP where Documento=" + documento;
                string fecha_contabilizacion = osql.get(oglobales.query, Conexion.AutCanjes);
                oglobales.query = "select FORMAT(Fecha,'yyyMMdd') as Fecha from TBL_EncabezadoSAP where Documento=" + documento;
                string fecha_documento = osql.get(oglobales.query, Conexion.AutCanjes);
                oglobales.query = "select Cod_Cliente_SAP from TBL_EncabezadoSAP where Documento=" + documento;
                string cliente = osql.get(oglobales.query, Conexion.AutCanjes);
                oglobales.query = "select Usuario_Salida from TBL_EncabezadoSAP where Documento=" + documento;
                string ref_doc_no = osql.get(oglobales.query, Conexion.AutCanjes);
                //1 - Fin Área de consultas

                IRfcFunction rfcfunction = rfcRepository.CreateFunction("ZRFC_GOODS_MOVEMENT_CANJES");
                IRfcStructure is_header = rfcfunction.GetStructure("IS_HEADER_MVT");
                is_header.SetValue("PSTNG_DATE", fecha_contabilizacion);
                is_header.SetValue("DOC_DATE", fecha_documento);
                is_header.SetValue("HEADER_TXT", header);
                is_header.SetValue("REF_DOC_NO", ref_doc_no);

                IRfcTable it_items = rfcfunction.GetTable("IT_ITEMS_MVT");

                oglobales.query = "select Cod_Prod_SAP,CENTRO,ALMACEN,LOTE,Cantidad_Enviar,UNIDAD,FECHA_CAD from TBL_DetalleSAP where Documento=" + documento + " and Mensaje1='SI_EXISTE' and Mensaje2='SI' and Mensaje3='CANJE' and Estado='A'";
                DataTable tabla = osql.ddt(oglobales.query, Conexion.AutCanjes);

                for (int zz = 0; zz <= tabla.Rows.Count - 1; zz++)
                {
                    //2 - Área de consultas
                    it_items.Append();
                    it_items.SetValue("MATERIAL", tabla.Rows[zz]["Cod_Prod_SAP"]);
                    it_items.SetValue("CENTRO", tabla.Rows[zz]["CENTRO"]);
                    it_items.SetValue("ALMACEN", tabla.Rows[zz]["ALMACEN"]);
                    it_items.SetValue("LOTE", tabla.Rows[zz]["LOTE"]);
                    it_items.SetValue("PROVEEDOR", proveedor);
                    it_items.SetValue("CLIENTE", cliente);
                    it_items.SetValue("CANTIDAD", Convert.ToDecimal(tabla.Rows[zz]["Cantidad_Enviar"]));
                    it_items.SetValue("UNIDAD", tabla.Rows[zz]["UNIDAD"]);
                    it_items.SetValue("RECEPTOR", receptor);
                    it_items.SetValue("FECHA_EXP", tabla.Rows[zz]["FECHA_CAD"]);
                    //2 - Fin Área de consultas
                }

                rfcfunction.Invoke(RfcDestination);
                EP_MATERIAL_DOCUMENT = rfcfunction.GetString("EP_MATERIAL_DOCUMENT");
                EP_DOCUMENT_YEAR = rfcfunction.GetString("EP_DOCUMENT_YEAR");
                ET_RETURN.Tables.Add(Convert_table_sap_to_DataTable(rfcfunction.GetTable("ET_RETURN")));

                TABLA_SALIDA.Columns.Add("EP_MATERIAL_DOCUMENT");
                TABLA_SALIDA.Columns.Add("EP_DOCUMENT_YEAR");
                TABLA_SALIDA.Columns.Add("TYPE");
                TABLA_SALIDA.Columns.Add("MESSAGE");
                TABLA_SALIDA.Columns.Add("ID");
                TABLA_SALIDA.Columns.Add("NUMBER");

                if (EP_MATERIAL_DOCUMENT == null)
                {
                    EP_MATERIAL_DOCUMENT = "";
                }

                if (EP_DOCUMENT_YEAR == null)
                {
                    EP_DOCUMENT_YEAR = "";
                }

                if (ET_RETURN.Tables[0].Rows.Count > 0)
                {
                    for (int n = 0; n <= ET_RETURN.Tables[0].Rows.Count - 1; n++)
                    {
                        TABLA_SALIDA.Rows.Add(EP_MATERIAL_DOCUMENT, EP_DOCUMENT_YEAR, ET_RETURN.Tables[0].Rows[n]["TYPE"], ET_RETURN.Tables[0].Rows[n]["MESSAGE"]);
                    }
                }
                else
                {
                    TABLA_SALIDA.Rows.Add(EP_MATERIAL_DOCUMENT, EP_DOCUMENT_YEAR, "", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return TABLA_SALIDA;
        }
        public DataTable ZRFC_GET_DATOS_DOC_MATERIAL(string destinationname, string documento, string year)
        {
            DataSet DATA = new DataSet();
            DataTable TABLA_SALIDA = new DataTable();
            string E_MENSAJE = "";

            try
            {
                if (RfcDestination == null)
                {
                    RfcDestination = RfcDestinationManager.GetDestination(destinationname);
                }
                RfcRepository rfcRepository = RfcDestination.Repository;
                //nombre de como se llama la api
                IRfcFunction rfcfunction = rfcRepository.CreateFunction("ZRFC_GET_DATOS_DOC_MATERIAL");
                //los campos que se mandan 
                rfcfunction.SetValue("I_MBLNR", documento);
                rfcfunction.SetValue("I_MJAHR", year);
                //se juntan para la llamada los datos
                rfcfunction.Invoke(RfcDestination);

                IRfcStructure ES_DATOS = rfcfunction.GetStructure("ES_DATOS");
                E_MENSAJE = rfcfunction.GetString("E_MENSAJE");
                DATA.Tables.Add(ConvertirEstructura(ES_DATOS));

                TABLA_SALIDA.Columns.Add("E_MENSAJE");
                TABLA_SALIDA.Columns.Add("NUM_PEDIDO");
                TABLA_SALIDA.Columns.Add("NUM_REF_SALIDA");
                TABLA_SALIDA.Columns.Add("GUI_REMISION");
                TABLA_SALIDA.Columns.Add("CAI");
                TABLA_SALIDA.Columns.Add("VALOR_NETO");
                TABLA_SALIDA.Columns.Add("DOC_ANULACION");
                TABLA_SALIDA.Columns.Add("MONEDA");
                TABLA_SALIDA.Columns.Add("PROVEEDOR");
                TABLA_SALIDA.Columns.Add("ALMACEN");
                TABLA_SALIDA.Columns.Add("ORG_COMPRAS");

                if (E_MENSAJE == "")
                {
                    for (int n = 0; n <= DATA.Tables[0].Rows.Count - 1; n++)
                    {
                        TABLA_SALIDA.Rows.Add(
                            E_MENSAJE,
                            DATA.Tables[0].Rows[n]["NUM_PEDIDO"],
                            DATA.Tables[0].Rows[n]["NUM_REF_SALIDA"],
                            DATA.Tables[0].Rows[n]["GUI_REMISION"],
                            DATA.Tables[0].Rows[n]["CAI"],
                            DATA.Tables[0].Rows[n]["VALOR_NETO"],
                            DATA.Tables[0].Rows[n]["DOC_ANULACION"],
                            DATA.Tables[0].Rows[n]["MONEDA"],
                            DATA.Tables[0].Rows[n]["PROVEEDOR"],
                            DATA.Tables[0].Rows[n]["ALMACEN"],
                            DATA.Tables[0].Rows[n]["ORG_COMPRAS"]
                            );
                    }
                }
                else
                {
                    TABLA_SALIDA.Rows.Add(E_MENSAJE, "", "", "", "", "", "", "", "", "", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR " + ex.Message);
            }
            return TABLA_SALIDA;
        }

        public class jsonrfcdevolucioneserror2
        {
            public string MATERIAL { get; set; }
            public string CENTRO { get; set; }
            public string ALMACEN { get; set; }
            public string LOTE { get; set; }
            public string FECHA_CAD { get; set; }
            public decimal CANTIDAD { get; set; }
            public string UNIDAD { get; set; }
            public string TYPE { get; set; }
            public string MESSAGE { get; set; }
            public string ID { get; set; }
            public string NUMBER { get; set; }
            public string MESSAGE_V1 { get; set; }
            public string MESSAGE_V2 { get; set; }

        }
    }
}
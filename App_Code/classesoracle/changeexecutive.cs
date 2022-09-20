using System;
using System.Data;
using System.Configuration;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for changeexecutive
    /// </summary>
    public class changeexecutive : orclconnection
    {
        public changeexecutive()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet update(string compcode, string langcode, string fontleading, string fontsize, string editioncode,string fontname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("update_fontleading ", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pLANGCODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = langcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pFONTLEADING", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fontleading;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pFONTSIZE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fontsize;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pEITIONCODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);




                OracleParameter prm6 = new OracleParameter("PFONTNAME", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = fontname;
                objOraclecommand.Parameters.Add(prm6);




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }




        public DataSet save(string compcode, string langcode, string fontleading, string fontsize, string editioncode,string fontname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("savefontleading", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pLANGCODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = langcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("FONTLEADING", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fontleading;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("FONTSIZE", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = fontsize;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("EITIONCODE", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = editioncode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("PFONTNAME", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = fontname;
                objOraclecommand.Parameters.Add(prm6);

             


            


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }


        public DataSet bindfontleading(string compcode,string edtioncode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("bind_fontgrid", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("peditioncode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = edtioncode;
                objOraclecommand.Parameters.Add(prm2);





                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }













        public DataSet updateexe(string compcol, string cioid, string executivecode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("updateexecutive", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcol;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pcioid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cioid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("pexecutivecode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = executivecode;
                objOraclecommand.Parameters.Add(prm3);

             


            


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }







        public DataSet bindexecutive(string comcode, string usid, string tname, string ext)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("xlsBindexecnew.xlsBindexecnew_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = comcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("userid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = usid;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm3 = new OracleParameter("name1", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = tname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("executive", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = ext;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;



            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }

        }



        public DataSet bindgridexecutive(string client, string agcode, string agsubcode, string id,string validfrom,string validto)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("bindexecutivegrid", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("pclientcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                if (client == "")
                {
                    prm1.Value = System.DBNull.Value;
                }
                else
                {

                    prm1.Value = client;
                }
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm2 = new OracleParameter("pagencycode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;

                if (agcode == "")
                {
                    prm2.Value = System.DBNull.Value.ToString();
                }
                else
                {
                    prm2.Value = agcode;
                }
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pagencysubcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (agsubcode == "")
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                {
                    prm3.Value = agsubcode;
                }

               
                objOraclecommand.Parameters.Add(prm3);



                OracleParameter prm4 = new OracleParameter("pcioid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;

                if (id == "")
                {
                    prm4.Value = System.DBNull.Value.ToString();
                }
                else
                {
                    prm4.Value = id;
                }
              
                objOraclecommand.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("validfrom", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;

                string dateformat = "dd/mm/yyyy";

                if (validfrom == "")
                {
                    validfrom = System.DBNull.Value.ToString();
                }
                else
                {

                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validfrom.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validfrom = mm + "/" + dd + "/" + yy;
                    }
                }


                prm5.Value = Convert.ToDateTime(validfrom).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm6 = new OracleParameter("validto", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;

                if (validto == "")
                {





                    validto = System.DBNull.Value.ToString();
                }
                else
                {




                    if (dateformat == "dd/mm/yyyy")
                    {
                        string[] arr = validto.Split('/');
                        string dd = arr[2];
                        string mm = arr[1];
                        string yy = arr[0];
                        validto = mm + "/" + dd + "/" + yy;
                    }
                }



                prm6.Value = Convert.ToDateTime(validto).ToString("dd-MMMM-yyyy"); 
                objOraclecommand.Parameters.Add(prm6);


                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }













        public DataSet submit(string compcode, string fromdate, string todate, string agency, string client, string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("executivefind", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("fdate", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = fromdate;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("tdate", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = todate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = agency;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("client", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = client;
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm7 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = cioid;
                objOraclecommand.Parameters.Add(prm7);




                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }


        }





    }
}
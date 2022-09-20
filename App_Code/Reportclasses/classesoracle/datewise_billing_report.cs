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

namespace NewAdbooking.Report.classesoracle
{

    /// <summary>
    /// Summary description for datewise_billing_report
    /// </summary>
    public class datewise_billing_report : orclconnection
    {
        public datewise_billing_report()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet category_billing(string compcode, string printcenter, string branchcode, string publication, string adtype, string catgcode, string fromdate, string dateto, string useid, string dateformat, string ext1, string ext2, string ext3,string ext4,string ext5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_category_billing_summ", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("pcompcode", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = compcode;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("pcenter", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    top2.Value = printcenter;
                }
                else
                {
                    top2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("pbranchcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode!="0"))
                {
                    prm1.Value = branchcode;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppublcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if ((publication != "") && (publication != "--Select Publication--") && (publication!="0"))
                {
                    prm2.Value = publication;
                    
                }
                else
                {
                    prm2.Value = System.DBNull.Value;
                    
                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm255 = new OracleParameter("padtype", OracleType.VarChar);
                prm255.Direction = ParameterDirection.Input;
                if ((adtype != "") && (adtype != "--Select Ad Type--") && (adtype!="0"))
                {
                    prm255.Value = adtype;
                }
                else
                {
                    prm255.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm255);

                OracleParameter prm6 = new OracleParameter("pcatgcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if ((catgcode != "") && (catgcode != "--Select Ad Cat--"))
                {
                    prm6.Value = catgcode;
                    
                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm3 = new OracleParameter("pdatefrom", OracleType.VarChar, 50);//pdatefrom
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdateto", OracleType.VarChar, 50);//pdateto
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateto;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm10 = new OracleParameter("puserid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = useid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ext1;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ext2;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = ext3;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = ext4;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = ext5;
                objOraclecommand.Parameters.Add(prm15);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet publication_billing(string compcode, string printcenter, string branchcode, string publication, string adtype, string catgcode, string fromdate, string dateto, string useid, string dateformat, string ext1, string ext2, string ext3, string ext4, string ext5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_publwise_billing_summ", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("pcompcode", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = compcode;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("pcenter", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    top2.Value = printcenter;
                }
                else
                {
                    top2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("pbranchcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    prm1.Value = branchcode;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppublcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    prm2.Value = publication;

                }
                else
                {
                    prm2.Value = System.DBNull.Value;

                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm255 = new OracleParameter("padtype", OracleType.VarChar);
                prm255.Direction = ParameterDirection.Input;
                if ((adtype != "") && (adtype != "--Select Ad Type--") && (adtype != "0"))
                {
                    prm255.Value = adtype;
                }
                else
                {
                    prm255.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm255);

                OracleParameter prm6 = new OracleParameter("pcatgcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if ((catgcode != "") && (catgcode != "--Select Ad Cat--"))
                {
                    prm6.Value = catgcode;

                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm3 = new OracleParameter("pdatefrom", OracleType.VarChar, 50);//pdatefrom
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pdateto", OracleType.VarChar, 50);//pdateto
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateto;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm10 = new OracleParameter("puserid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = useid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = ext1;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = ext2;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = ext3;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = ext4;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = ext5;
                objOraclecommand.Parameters.Add(prm15);

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

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
        public DataSet bind_function(string compcode, string catcode, string value)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                string query = "select  AD_GET_catnameE('" + compcode + "','" + catcode + "','" + value + "') from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }

        public DataSet bind_publication(string compcode, string pubcode)
        {
            OracleConnection con;
            OracleCommand cmd = new OracleCommand();
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                string query = "select ad_get_fieldname1 ('Comp_Code','" + compcode + "','Pub_Code','" + pubcode + "','Pub_Name','PUB_MAST','','') AS pubname from dual";
                cmd.CommandText = query;
                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


        public DataSet subcategory_billing(string compcode, string printcenter, string branchcode, string publication, string adtype, string catgcode, string fromdate, string dateto, string useid, string dateformat, string ext1, string ext2, string ext3, string ext4, string ext5)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {

                objOracleConnection.Open();
                objOraclecommand = GetCommand("rpt_category_dt_summary.rpt_category_dt_billing", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter top1 = new OracleParameter("pcompcode", OracleType.VarChar);
                top1.Direction = ParameterDirection.Input;
                top1.Value = compcode;
                objOraclecommand.Parameters.Add(top1);

                OracleParameter top2 = new OracleParameter("ppcentcode", OracleType.VarChar);
                top2.Direction = ParameterDirection.Input;
                if ((printcenter != "") && (printcenter != "--Select Printing Center--") && (printcenter != "0"))
                {
                    top2.Value = printcenter;
                }
                else
                {
                    top2.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(top2);

                OracleParameter prm1 = new OracleParameter("punitcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                if ((branchcode != "") && (branchcode != "--Select Branch--") && (branchcode != "0"))
                {
                    prm1.Value = branchcode;
                }
                else
                {
                    prm1.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("ppublcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                if ((publication != "") && (publication != "--Select Publication--") && (publication != "0"))
                {
                    prm2.Value = publication;

                }
                else
                {
                    prm2.Value = System.DBNull.Value;

                }
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm255 = new OracleParameter("padtype", OracleType.VarChar);
                prm255.Direction = ParameterDirection.Input;
                if ((adtype != "") && (adtype != "--Select Ad Type--") && (adtype != "0"))
                {
                    prm255.Value = adtype;
                }
                else
                {
                    prm255.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm255);

                OracleParameter prm6 = new OracleParameter("padcat", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if ((catgcode != "") && (catgcode != "--Select Ad Cat--"))
                {
                    prm6.Value = catgcode;

                }
                else
                {
                    prm6.Value = System.DBNull.Value;
                }
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm3 = new OracleParameter("pfrom_date", OracleType.VarChar, 50);//pdatefrom
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = fromdate;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("ptill_date", OracleType.VarChar, 50);//pdateto
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = dateto;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm10 = new OracleParameter("puserid", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = useid;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm11 = new OracleParameter("pextra1", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("pextra2", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pextra3", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("pextra4", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("pextra5", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm15);

                 OracleParameter prm141 = new OracleParameter("padsubcat", OracleType.VarChar);
                  prm141.Direction = ParameterDirection.Input;
                  prm141.Value = ext1;
                  objOraclecommand.Parameters.Add(prm141);

                OracleParameter prm142 = new OracleParameter("pad_subcat3", OracleType.VarChar);
                prm142.Direction = ParameterDirection.Input;
                prm142.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm142);

                OracleParameter prm143 = new OracleParameter("pad_subcat4", OracleType.VarChar);
                prm143.Direction = ParameterDirection.Input;
                prm143.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm143);

                OracleParameter prm144 = new OracleParameter("pad_subcat5", OracleType.VarChar);
                prm144.Direction = ParameterDirection.Input;
                prm144.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm144);

                OracleParameter prm145 = new OracleParameter("pdist_code", OracleType.VarChar);
                prm145.Direction = ParameterDirection.Input;
                prm145.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm145);

                OracleParameter prm146 = new OracleParameter("pedtncode", OracleType.VarChar);
                prm146.Direction = ParameterDirection.Input;
                prm146.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm146);

                OracleParameter prm147 = new OracleParameter("pteamcode", OracleType.VarChar);
                prm147.Direction = ParameterDirection.Input;
                prm147.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm147);

                OracleParameter prm148 = new OracleParameter("pexecode", OracleType.VarChar);
                prm148.Direction = ParameterDirection.Input;
                prm148.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm148);
                

                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts1"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts2"].Direction = ParameterDirection.Output;

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
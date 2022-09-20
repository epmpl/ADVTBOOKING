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
    /// Summary description for PublicationMaster
    /// </summary>
    public class PublicationMaster:orclconnection
    {
        public PublicationMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet addlang(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("PubAddLanguage.PubAddLanguage_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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


        // public DataSet pubsave(string compcode, string priority, string pubcode, string pubname, string pubalias, string langcode, string estdate, string contperson, string phone, string fax, string emailid, string userid)
        public DataSet pubsave(string compcode, string pubcode, string pubname, string pubalias, string langcode, string priority, string estdate, string contperson, string phone, string fax, string emailid, string userid, string pubtype, string preocity, string txtphone2, string txtfaxno1, string txtgutter, string txtcolspc, string hr, string mint, string prod, string noofcol, string publish_code, string prefix, string MRV, string integration, string mobileno, string acc_cd, string sacc_cd)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pubsave.pubsave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubalias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubalias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("langcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = langcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("priority", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = priority;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("estdate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (estdate != "")
                    prm7.Value = Convert.ToDateTime(estdate).ToString("dd-MMMM-yyyy");
                else
                    prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);

                /*
                objOraclecommand.Parameters.Add("estdate", SqlDbType.DateTime);
                if (estdate == "" || estdate == null || estdate == "undefined")
                {
                    objOraclecommand.Parameters["estdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objOraclecommand.Parameters["estdate"].Value = Convert.ToDateTime(estdate);

                }*/

                OracleParameter prm8 = new OracleParameter("contperson", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = contperson;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("phone", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = phone;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("fax", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = fax;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("emailid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = emailid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12 = new OracleParameter("userid", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = userid;
                objOraclecommand.Parameters.Add(prm12);

                OracleParameter prm13 = new OracleParameter("pubtype", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pubtype;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("phone2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = txtphone2;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("fax2", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = txtfaxno1;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm21 = new OracleParameter("preocity", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = preocity;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm16 = new OracleParameter("gutter_space", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = txtgutter;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("column_space", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = txtcolspc;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("hr", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = hr;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("mint", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = mint;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("prod", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = prod;
                objOraclecommand.Parameters.Add(prm20);
               
                OracleParameter prm24 = new OracleParameter("noofcol", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = noofcol;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("publish_code", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = publish_code;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("prefix", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = prefix;
                objOraclecommand.Parameters.Add(prm26);


                OracleParameter prm27 = new OracleParameter("mrv", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = MRV;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("integration", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                prm28.Value = integration;
                objOraclecommand.Parameters.Add(prm28);//mobile

                OracleParameter prm31 = new OracleParameter("mobile", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = mobileno;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm29 = new OracleParameter("psac_code", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                prm29.Value = acc_cd;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("psub_sac_code", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                prm30.Value = sacc_cd;
                objOraclecommand.Parameters.Add(prm30);

                

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


        public DataSet pubmodify(string compcode, string pubcode, string pubname, string pubalias, string langcode, string priority, string estdate, string contperson, string phone, string fax, string emailid, string userid, string pubtype, string preocity, string txtphone2, string txtfaxno1, string txtgutter, string txtcolspc, string hr, string mint, string prod, string noofcol, string publishcode, string prefix, string MRV, string moblieno)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pub_modify.pub_modify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("comcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubalias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubalias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("langcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = langcode;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("priority", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = priority;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("estdate", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (estdate != "")
                    prm7.Value = Convert.ToDateTime(estdate).ToString("dd-MMMM-yyyy");
                else
                    prm7.Value = System.DBNull.Value;
                objOraclecommand.Parameters.Add(prm7);
                /*
                objOraclecommand.Parameters.Add("estdate", SqlDbType.VarChar);
                //objOraclecommand.Parameters["estdate"].Value =estdate;
                //if(estdate!="" )
                if (estdate == "" || estdate == null)
                {
                    objOraclecommand.Parameters["estdate"].Value = System.DBNull.Value;
                }
                else
                {
                    objOraclecommand.Parameters["estdate"].Value = Convert.ToDateTime(estdate);
                }
                */
                OracleParameter prm8 = new OracleParameter("contperson", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = contperson;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("phone", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = phone;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("fax", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = fax;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("emailid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = emailid;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm13 = new OracleParameter("pubtype", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = pubtype;
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm21 = new OracleParameter("preocity", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = preocity;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm14 = new OracleParameter("phone2", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = txtphone2;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("fax2", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = txtfaxno1;
                objOraclecommand.Parameters.Add(prm15);


                OracleParameter prm16 = new OracleParameter("gutter_space", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = txtgutter;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("column_space", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = txtcolspc;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("hr", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = hr;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("mint", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = mint;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("prod", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                prm20.Value = prod;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm24 = new OracleParameter("noofcol", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                prm24.Value = noofcol;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("publishcode", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                prm25.Value = publishcode;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("prefix", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                prm26.Value = prefix;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("mrv", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                prm27.Value = MRV;
                objOraclecommand.Parameters.Add(prm27);



                //OracleParameter prm28 = new OracleParameter("mrv", OracleType.VarChar);
                //prm28.Direction = ParameterDirection.Input;
                //prm28.Value = MRV;
                //objOraclecommand.Parameters.Add(prm28);

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


        public DataSet pubexecute(string compcode, string pubcode, string pubname, string pubalias, string langcode, string pubtype, string preocity)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("pubexecute.pubexecute_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pubname", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = pubname;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pubalias", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = pubalias;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("langcode", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                if (langcode == "0")
                {
                    prm5.Value = System.DBNull.Value;
                }
                else
                {
                    prm5.Value = langcode;
                }
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm13 = new OracleParameter("pubtype", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (pubtype == "0")
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                {
                    prm13.Value = pubtype;
                }
                objOraclecommand.Parameters.Add(prm13);


                OracleParameter prm21 = new OracleParameter("preocity", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (preocity == "0")
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                {
                    prm21.Value = preocity;
                }
                objOraclecommand.Parameters.Add(prm21);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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


     
        public DataSet selectpublication()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("selectpublication.selectpublication_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

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



        public DataSet selectpubdaysave(string compcode, string pubcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectpubdaysave.slelectpubdaysave_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("all1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = all;
                objOraclecommand.Parameters.Add(prm10);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

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


        public DataSet checkpubcode(string compcode, string pubcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("checkpubcode.checkpubcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);

                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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





        public DataSet selectpubdaymodify(string compcode, string pubcode, string sun, string mon, string tue, string wed, string thu, string fri, string sat, string all, string userid)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("slelectpubdaymodify.slelectpubdaymodify_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("sun", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sun;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("mon", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = mon;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("tue", OracleType.VarChar);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = tue;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("wed", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = wed;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("thu", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = thu;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("fri", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = fri;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("sat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("all1", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = all;
                objOraclecommand.Parameters.Add(prm10);

           
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


        public DataSet pubdelete(string compcode, string pubcode)
        {

            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();

            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("publicationdelete.publicationdelete_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);

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


        public DataSet publicationcheck(string compcode, string pubcode, string userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("publicationcheck.publicationcheck_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("pubcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = pubcode;
                objOraclecommand.Parameters.Add(prm2);


                OracleParameter prm11 = new OracleParameter("userid", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = userid;
                objOraclecommand.Parameters.Add(prm11);


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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

        public DataSet publicationmastr(/*string cod,*/string str)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("autopublicatcode.autopublicatcode_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("str", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = str;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12= new OracleParameter("cod", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm12.Value = str.Substring(0, 2);
                    objOraclecommand.Parameters.Add(prm12);
                }
                else
                {
                    prm12.Value = str;
                    objOraclecommand.Parameters.Add(prm12);
                }


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("P_ACCOUNT1", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT1"].Direction = ParameterDirection.Output;


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


        public DataSet pubcity(string citycode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("publicationcity.publicationcity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("citycode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = citycode;
                objOraclecommand.Parameters.Add(prm11);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

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

        public DataSet publicationtype()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("addpublicationtype.addpublicationtype_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;


                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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


        public DataSet preodicityname(string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("addpreodicity.addpreodicity_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm11 = new OracleParameter("compcode", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compcode;
                objOraclecommand.Parameters.Add(prm11);
                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;

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

        //*********************By Manish*************************************
        public DataSet chkPriority(string compCode, string priority)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkPubPriority.chkPubPriority_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm11 = new OracleParameter("comp_code", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = compCode;
                objOraclecommand.Parameters.Add(prm11);

                OracleParameter prm12= new OracleParameter("Priority", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = priority;
                objOraclecommand.Parameters.Add(prm12);

                objOraclecommand.Parameters.Add("P_ACCOUNT", OracleType.Cursor);
                objOraclecommand.Parameters["P_ACCOUNT"].Direction = ParameterDirection.Output;


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
     
        //================ ad by rinki=======================///

        public DataSet publisher(string compcode)
        {
            OracleConnection con;
            OracleCommand cmd;
            con = GetConnection();
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();


            try
            {
                con.Open();
                cmd = GetCommand("bindpublisher", ref con);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                cmd.Parameters.Add(prm2);

                cmd.Parameters.Add("p_accounts", OracleType.Cursor);
                cmd.Parameters["p_accounts"].Direction = ParameterDirection.Output;



                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection(ref con);
            }
        }


    }
}
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

/// <summary>
/// Summary description for UOM
/// </summary>
public class UOM : orclconnection 
{
	public UOM()
	{
		//
		// TODO: Add constructor logic here
		//
	}
      public DataSet checkuomcode(string code,string txtuomdesc, string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("checkuom.checkuom_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm4 = new OracleParameter("uomname", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtuomdesc;
                objOraclecommand.Parameters.Add(prm4);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;
			
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
			catch(OracleException  objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}

        public DataSet countuomcode(string str,string compcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("chkuomcodename.chkuomcodename_p", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;                


                OracleParameter prm2 = new OracleParameter("str", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = str;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("cod", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (str.Length > 2)
                {
                    prm3.Value = str.Substring(0, 2);
                }
                else
                {
                    prm3.Value = str;
                }
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("company_code", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;



                objmysqlDataAdapter.SelectCommand = objOraclecommand ;
                objmysqlDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }

        public DataSet insertinuom(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype,string adtype,string sampleimg,string stylesheet, string uom_desc,string logo, string logouom,string column,string gutwidth,string colwidth, string acc_cd, string sacc_cd)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("insertuom.insertuom_P", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;	       


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtuomcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtuomcode;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("txtuomdesc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtuomdesc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("txtalias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtalias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("txtuomtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txtuomtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adtype;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("sample_img_hm", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sampleimg;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("stylesheetname", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = stylesheet;
                objOraclecommand.Parameters.Add(prm10);
                OracleParameter prm11 = new OracleParameter("uom_desc", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = uom_desc;
                objOraclecommand.Parameters.Add(prm11);
                OracleParameter prm12 = new OracleParameter("logo", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = logo;
                objOraclecommand.Parameters.Add(prm12);
                OracleParameter prm13 = new OracleParameter("logouom", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = logouom;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("column", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = column;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("gutwidth", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = gutwidth;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("colwidth", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = colwidth;
                objOraclecommand.Parameters.Add(prm16);
                // acc_cd, sacc_cd
                OracleParameter prm17 = new OracleParameter("SAC_CODE", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = acc_cd;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("SUB_SAC_CODE", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = sacc_cd;
                objOraclecommand.Parameters.Add(prm18);

				
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}

        public DataSet executeuom(string compcode, string userid, string txtuomcode, string txtuomdesc, string txtalias, string adtype, string uomtype)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("executeuom.executeuom_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
              


                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtuomcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtuomcode;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("txtuomdesc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtuomdesc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("txtalias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtalias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("uomtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                if (uomtype=="0")
                {
                    prm7.Value =System.DBNull.Value;

                }
                else
                {
                     prm7.Value = uomtype;
               
                }
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                if (adtype=="0")
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                {
                prm8.Value = adtype;
                }
                objOraclecommand.Parameters.Add(prm8);


                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


				
	
				
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
          
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}

		public DataSet firstquery()
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();	
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("firstuom.firstuom_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;



                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;


				
				
				
				
				
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}
        public DataSet updaetcode(string txtuomcode, string txtuomdesc, string txtalias, string compcode, string userid, string txtuomtype, string adtype, string sampleimg, string stylesheet, string uom_desc, string logo, string logouom, string column, string gutwidth, string colwidth, string acc_cd, string sacc_cd)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("updateuom.updateuom_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;

             



                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("txtuomcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = txtuomcode;
                objOraclecommand.Parameters.Add(prm4);
                OracleParameter prm5 = new OracleParameter("txtuomdesc", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = txtuomdesc;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("txtalias", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = txtalias;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm7 = new OracleParameter("txtuomtype", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = txtuomtype;
                objOraclecommand.Parameters.Add(prm7);

                OracleParameter prm8 = new OracleParameter("adtype", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = adtype;
                objOraclecommand.Parameters.Add(prm8);

                OracleParameter prm9 = new OracleParameter("sample_img_hm", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = sampleimg;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("stylesheetname", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = stylesheet;
                objOraclecommand.Parameters.Add(prm10);
                OracleParameter prm11 = new OracleParameter("uom_desc1", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = uom_desc;
                objOraclecommand.Parameters.Add(prm11);
                OracleParameter prm12 = new OracleParameter("logo", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = logo;
                objOraclecommand.Parameters.Add(prm12);
                OracleParameter prm13 = new OracleParameter("logouom", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = logouom;
                objOraclecommand.Parameters.Add(prm13);

                OracleParameter prm14 = new OracleParameter("column", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = column;
                objOraclecommand.Parameters.Add(prm14);


                OracleParameter prm15 = new OracleParameter("gutwidth", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = gutwidth;
                objOraclecommand.Parameters.Add(prm15);



                OracleParameter prm16 = new OracleParameter("colwidth", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = colwidth;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("sac_code1", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = acc_cd;
                objOraclecommand.Parameters.Add(prm17);


                OracleParameter prm18 = new OracleParameter("sub_sac_code1", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = sacc_cd;
                objOraclecommand.Parameters.Add(prm18);
				
				
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}

		public DataSet deleteuom(string code,string compcode,string userid)
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("deleteuom.deleteuom_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;
 
				

                OracleParameter prm2 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);



                OracleParameter prm3 = new OracleParameter("userid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm1 = new OracleParameter("code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = code;
                objOraclecommand.Parameters.Add(prm1);


              
                



				
				
				
				
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}
		public DataSet bindes()
		{
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objmysqlDataAdapter = new OracleDataAdapter();
			try
			{
				objOracleConnection.Open();
                objOraclecommand = GetCommand("fromuom.fromuom_p", ref objOracleConnection);
				objOraclecommand.CommandType = CommandType.StoredProcedure;




                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

				
				
				objmysqlDataAdapter.SelectCommand =objOraclecommand ;
				objmysqlDataAdapter.Fill(objDataSet);
				return objDataSet;


			}
            catch (OracleException objException)
			{
				throw(objException);
			}
			catch(Exception ex)
			{
				throw(ex);	
			}
			finally
			{
                objOracleConnection.Close();
			}
		
		}
	}
}

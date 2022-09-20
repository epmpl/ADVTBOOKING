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
    /// Summary description for cat_map
    /// </summary>
    public class cat_map : orclconnection
    {
        public cat_map()
        {
            //
            // TODO: Add constructor logic here
            //
        }

           public DataSet mappingchk(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
        {
           


                OracleConnection con;
            OracleCommand com;
            DataSet ds = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_chkmapping.websp_chkmapping_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

          

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);

     


                OracleParameter prm2 = new OracleParameter("sourceregion", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sourceregion;
                com.Parameters.Add(prm2);


                OracleParameter prm11 = new OracleParameter("sourcevariable", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = sourcevariable;
                com.Parameters.Add(prm11);


          

                OracleParameter prm12 = new OracleParameter("sourcecat1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = sourcecat1;
                com.Parameters.Add(prm12);


       
                OracleParameter prm13 = new OracleParameter("sourcecat2", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = sourcecat2;
                com.Parameters.Add(prm13);



     



                OracleParameter prm14 = new OracleParameter("sourcecat3", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = sourcecat3;
                com.Parameters.Add(prm14);


     

                OracleParameter prm15 = new OracleParameter("sourcecat4", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = sourcecat4;
                com.Parameters.Add(prm15);






                OracleParameter prm16 = new OracleParameter("sourcecat5", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sourcecat5;
                com.Parameters.Add(prm16);


    
                OracleParameter prm17 = new OracleParameter("destedit", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = destedit;
                com.Parameters.Add(prm17);


   


                OracleParameter prm18 = new OracleParameter("destreg", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = destreg;
                com.Parameters.Add(prm18);


           

                OracleParameter prm19 = new OracleParameter("destvar", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = destvar;
                com.Parameters.Add(prm19);


 


                OracleParameter prm21 = new OracleParameter("destcat1", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = destcat1;
                com.Parameters.Add(prm21);


       



                OracleParameter prm31 = new OracleParameter("destcat2", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = destcat2;
                com.Parameters.Add(prm31);


    


                OracleParameter prm41 = new OracleParameter("destcat3", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = destcat3;
                com.Parameters.Add(prm41);


         

                OracleParameter prm51 = new OracleParameter("destcat4", OracleType.VarChar, 50);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = destcat4;
                com.Parameters.Add(prm51);


         



                OracleParameter prm61 = new OracleParameter("destcat5", OracleType.VarChar, 50);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = destcat5;
                com.Parameters.Add(prm61);


                com.Parameters.Add("p_Accounts", OracleType.Cursor);
                com.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

      



            

                da.SelectCommand = com;
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


        public DataSet mappingsave(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
        {
            
                OracleConnection con;
            OracleCommand com;
            DataSet ds = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_savemapping.websp_savemapping_p", ref con);
                com.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);



       

                OracleParameter prm12 = new OracleParameter("sourceregion", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = sourceregion;
                com.Parameters.Add(prm12);





                OracleParameter prm13 = new OracleParameter("sourcevariable", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = sourcevariable;
                com.Parameters.Add(prm13);



         


                OracleParameter prm14 = new OracleParameter("sourcecat1", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = sourcecat1;
                com.Parameters.Add(prm14);


   

                OracleParameter prm24 = new OracleParameter("sourcecat2", OracleType.VarChar, 50);
                prm24.Direction = ParameterDirection.Input;
                if (sourcecat2 == "")
                {
                    prm24.Value = "0";
                }

                else
                {
                    prm24.Value = sourcecat2;

                }
                com.Parameters.Add(prm24);





                OracleParameter prm34 = new OracleParameter("sourcecat3", OracleType.VarChar, 50);
                prm34.Direction = ParameterDirection.Input;
                if (sourcecat3 == "")
                {
                    prm34.Value  = "0";
                }
                else
                {
                    prm34.Value = sourcecat3;
                } 

                com.Parameters.Add(prm34);

        

                OracleParameter prm44 = new OracleParameter("sourcecat4", OracleType.VarChar, 50);
                prm44.Direction = ParameterDirection.Input;
                if (sourcecat4 == "")
                {
                    prm44.Value  = "0";
                }
                else
                {
                    prm44.Value  = sourcecat4;
                } 
                com.Parameters.Add(prm44);

   


                OracleParameter prm54 = new OracleParameter("sourcecat5", OracleType.VarChar, 50);
                prm54.Direction = ParameterDirection.Input;
                if (sourcecat5 == "")
                {
                    prm54.Value = "0";
                }
                else
                {
                    prm54.Value = sourcecat5;
                } 
                com.Parameters.Add(prm54);


   



                OracleParameter prm15 = new OracleParameter("destedit", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = destedit;
                com.Parameters.Add(prm15);


       

                OracleParameter prm16 = new OracleParameter("destreg", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = destreg;
                com.Parameters.Add(prm16);


        


                OracleParameter prm17 = new OracleParameter("destvar", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = destvar;
                com.Parameters.Add(prm17);




          
             


                OracleParameter prm77 = new OracleParameter("destcat1", OracleType.VarChar, 50);
                prm77.Direction = ParameterDirection.Input;
                if (destcat1 == "")
                {
                    prm77.Value = "0";
                }
                else
                {
                    prm77.Value= destcat1;

                }
                com.Parameters.Add(prm77);





                OracleParameter prm64 = new OracleParameter("destcat2", OracleType.VarChar, 50);
                prm64.Direction = ParameterDirection.Input;
                if (destcat2 == "")
                {
                    prm64.Value = "0";
                }
                else
                {
                    prm64.Value = destcat2;

                }
                com.Parameters.Add(prm64);


        



                OracleParameter prm74 = new OracleParameter("destcat3", OracleType.VarChar, 50);
                prm74.Direction = ParameterDirection.Input;
                if (destcat3 == "")
                {
                    prm74.Value = "0";
                }
                else
                {
                    prm74.Value = destcat3;

                }
                com.Parameters.Add(prm74);


     



                OracleParameter prm84 = new OracleParameter("destcat4", OracleType.VarChar, 50);
                prm84.Direction = ParameterDirection.Input;
                if (destcat4 == "")
                {
                    prm84.Value = "0";
                }
                else
                {
                    prm84.Value = destcat4;

                }
                com.Parameters.Add(prm84);





                OracleParameter prm94 = new OracleParameter("destcat5", OracleType.VarChar, 50);
                prm94.Direction = ParameterDirection.Input;
                if (destcat5 == "")
                {
                    prm94.Value= "0";
                }
                else
                {
                    prm94.Value = destcat5;

                }
                com.Parameters.Add(prm94);



      



             
                da.SelectCommand = com;
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


        public DataSet modifychk(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5,string primary)
        {
           
                OracleConnection con;
            OracleCommand com;
            DataSet ds = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_modifychk.websp_modifychk_p", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);


        


                OracleParameter prm11 = new OracleParameter("sourceregion", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = sourceregion;
                com.Parameters.Add(prm11);



       

                OracleParameter prm12 = new OracleParameter("sourcevariable", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = sourcevariable;
                com.Parameters.Add(prm12);



         


                OracleParameter prm13 = new OracleParameter("sourcecat1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = sourcecat1;
                com.Parameters.Add(prm13);



        


                OracleParameter prm14 = new OracleParameter("sourcecat2", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = sourcecat2;
                com.Parameters.Add(prm14);



          

                OracleParameter prm15 = new OracleParameter("sourcecat3", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = sourcecat3;
                com.Parameters.Add(prm15);



      


                OracleParameter prm16 = new OracleParameter("sourcecat4", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = sourcecat4;
                com.Parameters.Add(prm16);


       

                OracleParameter prm17 = new OracleParameter("sourcecat5", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = sourcecat5;
                com.Parameters.Add(prm17);



       


                OracleParameter prm18 = new OracleParameter("destedit", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = destedit;
                com.Parameters.Add(prm18);



        

                OracleParameter prm19 = new OracleParameter("destreg", OracleType.VarChar, 50);
                prm19.Direction = ParameterDirection.Input;
                prm19.Value = destreg;
                com.Parameters.Add(prm19);





                OracleParameter prm21 = new OracleParameter("destvar", OracleType.VarChar, 50);
                prm21.Direction = ParameterDirection.Input;
                prm21.Value = destvar;
                com.Parameters.Add(prm21);






                OracleParameter prm31 = new OracleParameter("destcat1", OracleType.VarChar, 50);
                prm31.Direction = ParameterDirection.Input;
                prm31.Value = destcat1;
                com.Parameters.Add(prm31);



        

                OracleParameter prm41 = new OracleParameter("destcat2", OracleType.VarChar, 50);
                prm41.Direction = ParameterDirection.Input;
                prm41.Value = destcat2;
                com.Parameters.Add(prm41);






                OracleParameter prm51 = new OracleParameter("destcat3", OracleType.VarChar, 50);
                prm51.Direction = ParameterDirection.Input;
                prm51.Value = destcat3;
                com.Parameters.Add(prm51);



        


                OracleParameter prm61 = new OracleParameter("destcat4", OracleType.VarChar, 50);
                prm61.Direction = ParameterDirection.Input;
                prm61.Value = destcat4;
                com.Parameters.Add(prm61);



         


                OracleParameter prm71 = new OracleParameter("destcat5", OracleType.VarChar, 50);
                prm71.Direction = ParameterDirection.Input;
                prm71.Value = destcat5;
                com.Parameters.Add(prm71);





                OracleParameter prm91 = new OracleParameter("primary", OracleType.VarChar, 50);
                prm91.Direction = ParameterDirection.Input;
                prm91.Value = primary;
                com.Parameters.Add(prm91);


              

                com.Parameters.Add("p_Accounts", OracleType.Cursor);
                com.Parameters["p_Accounts"].Direction = ParameterDirection.Output;

      

                da.SelectCommand = com;
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

        public DataSet mappingmodify(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5,string primary)
        {
            
                OracleConnection con;
            OracleCommand com;
            DataSet ds = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_modifymapping.websp_modifymapping_p", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);


          


                OracleParameter prm11 = new OracleParameter("sourceregion", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = sourceregion;
                com.Parameters.Add(prm11);


          


                OracleParameter prm12 = new OracleParameter("sourcevariable", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = sourcevariable;
                com.Parameters.Add(prm12);



        





                OracleParameter prm13 = new OracleParameter("sourcecat1", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = sourcecat1;
                com.Parameters.Add(prm13);



                OracleParameter prm91 = new OracleParameter("sourcecat2", OracleType.VarChar, 50);
                prm91.Direction = ParameterDirection.Input;
                if (sourcecat2 == "")
                {
                    prm91.Value = "0";
                }
                else
                {
                    prm91.Value  = sourcecat2;

                }
                com.Parameters.Add(prm91);








                OracleParameter prm92 = new OracleParameter("sourcecat3", OracleType.VarChar, 50);
                prm92.Direction = ParameterDirection.Input;
                if (destcat4 == "")
                {
                    prm92.Value  = "0";
                }
                else
                {
                    prm92.Value = sourcecat3;

                }
                com.Parameters.Add(prm92);






                OracleParameter prm94 = new OracleParameter("sourcecat4", OracleType.VarChar, 50);
                prm94.Direction = ParameterDirection.Input;
                if (destcat4 == "")
                {
                    prm94.Value = "0";
                }
                else
                {
                    prm94.Value  = sourcecat4;

                }
                com.Parameters.Add(prm94);





                OracleParameter prm96 = new OracleParameter("sourcecat5", OracleType.VarChar, 50);
                prm96.Direction = ParameterDirection.Input;
                if (destcat4 == "")
                {
                    prm96.Value  = "0";
                }
                else
                {
                    prm96.Value  = sourcecat5;

                }
                com.Parameters.Add(prm96);


           


                OracleParameter prm15 = new OracleParameter("destedit", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = destedit;
                com.Parameters.Add(prm15);




                OracleParameter prm16 = new OracleParameter("destreg", OracleType.VarChar, 50);
                prm16.Direction = ParameterDirection.Input;
                prm16.Value = destreg;
                com.Parameters.Add(prm16);





                OracleParameter prm17 = new OracleParameter("destvar", OracleType.VarChar, 50);
                prm17.Direction = ParameterDirection.Input;
                prm17.Value = destvar;
                com.Parameters.Add(prm17);




                OracleParameter prm2 = new OracleParameter("destcat1", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                if (destcat1 == "")
                {
                    prm2.Value = "0";
                }
                else
                {
                    prm2.Value = destcat1;
                }
                com.Parameters.Add(prm2);


         

                OracleParameter prm3= new OracleParameter("destcat2", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                if (destcat2 == "")
                {
                    prm3.Value = "0";
                }
                else
                {
                    prm3.Value = destcat2;
                }
                com.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("destcat3", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                if (destcat3 == "")
                {
                    prm4.Value = "0";
                }
                else
                {
                    prm4.Value = destcat3;
                }
                com.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("destcat4", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                if (destcat4 == "")
                {
                    prm5.Value = "0";
                }
                else
                {
                    prm5.Value = destcat4;
                }
                com.Parameters.Add(prm5);


      


                OracleParameter prm6 = new OracleParameter("destcat5", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (destcat5 == "")
                {
                    prm6.Value = "0";
                }
                else
                {
                    prm6.Value  = destcat5;
                }
                com.Parameters.Add(prm6);

      





                OracleParameter prm18 = new OracleParameter("primary", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = primary;
                com.Parameters.Add(prm18);



               da.SelectCommand = com;
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

        public DataSet execute(string compcode, string sourceregion, string sourcevariable, string sourcecat1, string sourcecat2, string sourcecat3, string sourcecat4, string sourcecat5, string destedit, string destreg, string destvar, string destcat1, string destcat2, string destcat3, string destcat4, string destcat5)
        {
            
                OracleConnection con;
            OracleCommand com;
            DataSet ds = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_executecatmap.websp_executecatmap_p", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);

       

                OracleParameter prm2 = new OracleParameter("sourceregion", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = sourceregion;
                com.Parameters.Add(prm2);


       
       


                OracleParameter prm3 = new OracleParameter("sourcevariable", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = sourcevariable;
                com.Parameters.Add(prm3);




                OracleParameter prm4 = new OracleParameter("sourcecat1", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = sourcecat1;
                com.Parameters.Add(prm4);



                OracleParameter prm5 = new OracleParameter("sourcecat2", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = sourcecat2;
                com.Parameters.Add(prm5);


                OracleParameter prm6 = new OracleParameter("sourcecat3", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = sourcecat3;
                com.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("sourcecat4", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = sourcecat4;
                com.Parameters.Add(prm7);

      


                OracleParameter prm8 = new OracleParameter("sourcecat5", OracleType.VarChar, 50);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = sourcecat5;
                com.Parameters.Add(prm8);



                OracleParameter prm9 = new OracleParameter("destedit", OracleType.VarChar, 50);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = destedit;
                com.Parameters.Add(prm9);


   


                OracleParameter prm10 = new OracleParameter("destreg", OracleType.VarChar, 50);
                prm10.Direction = ParameterDirection.Input;
                prm10.Value = destreg;
                com.Parameters.Add(prm10);




                OracleParameter prm11 = new OracleParameter("destvar", OracleType.VarChar, 50);
                prm11.Direction = ParameterDirection.Input;
                prm11.Value = destvar;
                com.Parameters.Add(prm11);




                OracleParameter prm12 = new OracleParameter("destcat1", OracleType.VarChar, 50);
                prm12.Direction = ParameterDirection.Input;
                prm12.Value = destcat1;
                com.Parameters.Add(prm12);





                OracleParameter prm13 = new OracleParameter("destcat2", OracleType.VarChar, 50);
                prm13.Direction = ParameterDirection.Input;
                prm13.Value = destcat2;
                com.Parameters.Add(prm13);





                OracleParameter prm14 = new OracleParameter("destcat3", OracleType.VarChar, 50);
                prm14.Direction = ParameterDirection.Input;
                prm14.Value = destcat3;
                com.Parameters.Add(prm14);




                OracleParameter prm15 = new OracleParameter("destcat4", OracleType.VarChar, 50);
                prm15.Direction = ParameterDirection.Input;
                prm15.Value = destcat4;
                com.Parameters.Add(prm15);




                OracleParameter prm18 = new OracleParameter("destcat5", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = destcat5;
                com.Parameters.Add(prm18);




                com.Parameters.Add("p_Accounts", OracleType.Cursor);
                com.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                //com.Parameters.Add("p_Accounts1", OracleType.Cursor);
                //com.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;

      
      

                da.SelectCommand = com;
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

        public DataSet deletcatmap(string primary, string compcode)
        {
             OracleConnection con;
            OracleCommand com;
            DataSet ds = new DataSet();
            con = GetConnection();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                con.Open();
                com = GetCommand("websp_deletecatmap.websp_deletecatmap_p", ref con);
                com.CommandType = CommandType.StoredProcedure;



                OracleParameter prm1 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                com.Parameters.Add(prm1);




                OracleParameter prm18 = new OracleParameter("primary", OracleType.VarChar, 50);
                prm18.Direction = ParameterDirection.Input;
                prm18.Value = primary;
                com.Parameters.Add(prm18);



         


                


                da.SelectCommand = com;
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

    }
}
   

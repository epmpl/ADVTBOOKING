using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OracleClient;

/// <summary>
/// Summary description for clientexecmastr
/// </summary>
/// 
namespace NewAdbooking.classesoracle
{

    public class dealprovision1 : orclconnection
    {
        public dealprovision1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet Fetchdata(string compcode, string fdate, string todate, string deal, string agency, string client, string pub, string Filter, string uid, string dateformat,string adtype,string uom)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Fetchbookingdealdata", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcompcode", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


                OracleParameter prm5 = new OracleParameter("pfrdt", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                if (fdate == "")
                    prm5.Value = fdate;
                else
                    prm5.Value = Convert.ToDateTime(fdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("ptodt", OracleType.VarChar, 1000);
                prm6.Direction = ParameterDirection.Input;
                if (todate == "")
                    prm6.Value = todate;
                else
                    prm6.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm2 = new OracleParameter("pdeal", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = deal;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pagency", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = agency;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pclient", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = client;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("ppub", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = pub;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm8 = new OracleParameter("puid", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = uid;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pdateformat", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                prm9.Value = dateformat;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pFilter", OracleType.VarChar);
                    prm10.Direction = ParameterDirection.Input;
                    prm10.Value = Filter;
                    objOraclecommand.Parameters.Add(prm10);

                    OracleParameter prm11 = new OracleParameter("padtype", OracleType.VarChar);
                    prm11.Direction = ParameterDirection.Input;
                    if (adtype == "" || adtype == "0")
                    {
                        prm11.Value = System.DBNull.Value;
                    }
                    else
                    {
                        prm11.Value = adtype;
                    }
                    objOraclecommand.Parameters.Add(prm11);

                    OracleParameter prm12 = new OracleParameter("puomcode", OracleType.VarChar);
                    prm12.Direction = ParameterDirection.Input;
                    if (uom == "" || uom == "0")
                    {
                        prm12.Value = System.DBNull.Value;

                    }
                    else
                    {
                        prm12.Value = uom;
                    }
                    objOraclecommand.Parameters.Add(prm12);

                

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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



        public DataSet adddealprovisionsave(string compcode, string agencycode, string clientcode, string contractid, string billno, string billdate, string billamt, string billrate, string discrate, string creditnoterate, string totalinsertion, string userid, string insertid, string reamarks, string bookingid, string traddiscount, string ADDITIONALFLAG, string INSERTSTATUS, string DISCRATE, string addcomm, string CHKTRADEDISC, string TRANSLATIONPREMIUM, string TRANSLATIONDISC, string TRANSLATIONTYPE, string SPECIALDISCOUNT, string SPACEDISCOUNT, string SPECIALCHARGES, string PACKAGECODE, string DISCTYPE, string PREMPER, string SPECIALDISCPER, string DISCOUNT, string DISCOUNTPER, string SPACEDISCPER, string PREMIUMCHARGESTYPE, string AGCITY, string ADTYPE, string UOMCODE, string TRANSLATIONCODE, string PAGEPREM, string PAGEPOSITIONCODE, string PAGEAMOUNT, string POSPREMDISC, string BKDATE, string colorcode)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("dealprovisionsave", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);


              

                OracleParameter prm2 = new OracleParameter("pagcode", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = agencycode;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pclientcode", OracleType.VarChar);
                prm3.Direction = ParameterDirection.Input;
                if (clientcode == "" || clientcode==null)
                {
                    prm3.Value = System.DBNull.Value;
                }
                else
                prm3.Value = clientcode;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("pcontractid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                if (contractid == "" || contractid == null)
                {
                    prm4.Value = System.DBNull.Value;
                }
                else
                prm4.Value = contractid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("pbilldate", OracleType.VarChar, 1000);
                prm5.Direction = ParameterDirection.Input;
                if (billdate == "")
                    prm5.Value = System.DBNull.Value;
                else
                    prm5.Value = Convert.ToDateTime(billdate).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm5);



                OracleParameter prm7 = new OracleParameter("pbillno", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                if (billno == "" || billno == null)
                {
                    prm7.Value = System.DBNull.Value;
                }
                else
                 prm7.Value = billno;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("pbillamt", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;

                if (billamt == "" || billamt == null)
                {
                    prm8.Value = System.DBNull.Value;
                }
                else
                prm8.Value = billamt;
                objOraclecommand.Parameters.Add(prm8);


                OracleParameter prm9 = new OracleParameter("pbillrate", OracleType.VarChar);
                prm9.Direction = ParameterDirection.Input;
                if (billrate == "" || billrate == null)
                {
                    prm9.Value = System.DBNull.Value;
                }
                else
                prm9.Value = billrate;
                objOraclecommand.Parameters.Add(prm9);

                OracleParameter prm10 = new OracleParameter("pdicrate", OracleType.VarChar);
                prm10.Direction = ParameterDirection.Input;
                if (discrate == "" || discrate == null)
                {
                    prm10.Value = System.DBNull.Value;
                }
                else
                prm10.Value = discrate;
                objOraclecommand.Parameters.Add(prm10);


                OracleParameter prm11 = new OracleParameter("pcrednotrate", OracleType.VarChar);
                prm11.Direction = ParameterDirection.Input;
                if (creditnoterate == "" || creditnoterate == null)
                {
                    prm11.Value = System.DBNull.Value;
                }
                else
                prm11.Value = creditnoterate;
                objOraclecommand.Parameters.Add(prm11);


                OracleParameter prm12 = new OracleParameter("ptotalinsertion", OracleType.VarChar);
                prm12.Direction = ParameterDirection.Input;
                if (totalinsertion == "" || totalinsertion == null)
                {
                    prm12.Value = System.DBNull.Value;
                }
                else
                prm12.Value = totalinsertion;
                objOraclecommand.Parameters.Add(prm12);



                OracleParameter prm13 = new OracleParameter("puesrid", OracleType.VarChar);
                prm13.Direction = ParameterDirection.Input;
                if (userid == "" || userid == null)
                {
                    prm13.Value = System.DBNull.Value;
                }
                else
                prm13.Value = userid;
                objOraclecommand.Parameters.Add(prm13);



                OracleParameter prm14 = new OracleParameter("pinsertid", OracleType.VarChar);
                prm14.Direction = ParameterDirection.Input;
                if (insertid == "" || insertid == null)
                {
                    prm14.Value = System.DBNull.Value;
                }
                else
                prm14.Value = insertid;
                objOraclecommand.Parameters.Add(prm14);

                OracleParameter prm15 = new OracleParameter("premarks", OracleType.VarChar);
                prm15.Direction = ParameterDirection.Input;
                if (reamarks == "" || reamarks == null)
                {
                    prm15.Value = System.DBNull.Value;
                }
                else
                prm15.Value = reamarks;
                objOraclecommand.Parameters.Add(prm15);

                OracleParameter prm16 = new OracleParameter("pbookingid", OracleType.VarChar);
                prm16.Direction = ParameterDirection.Input;
                if (bookingid == "" || bookingid == null)
                {
                    prm16.Value = System.DBNull.Value;
                }
                else
                prm16.Value = bookingid;
                objOraclecommand.Parameters.Add(prm16);

                OracleParameter prm17 = new OracleParameter("ptraddiscount", OracleType.VarChar);
                prm17.Direction = ParameterDirection.Input;
                if (traddiscount == "" || traddiscount == null || traddiscount == "null")
                {
                    prm17.Value = System.DBNull.Value;
                }
                else
                    prm17.Value = traddiscount;
                objOraclecommand.Parameters.Add(prm17);

                OracleParameter prm18 = new OracleParameter("pADDITIONALFLAG", OracleType.VarChar);
                prm18.Direction = ParameterDirection.Input;
                if (ADDITIONALFLAG == "" || ADDITIONALFLAG == null || ADDITIONALFLAG == "null")
                {
                    prm18.Value = System.DBNull.Value;
                }
                else
                    prm18.Value = ADDITIONALFLAG;
                objOraclecommand.Parameters.Add(prm18);

                OracleParameter prm19 = new OracleParameter("pINSERTSTATUS", OracleType.VarChar);
                prm19.Direction = ParameterDirection.Input;
                if (INSERTSTATUS == "" || INSERTSTATUS == null || INSERTSTATUS == "null")
                {
                    prm19.Value = System.DBNull.Value;
                }
                else
                    prm19.Value = INSERTSTATUS;
                objOraclecommand.Parameters.Add(prm19);

                OracleParameter prm20 = new OracleParameter("pDISCRATE", OracleType.VarChar);
                prm20.Direction = ParameterDirection.Input;
                if (DISCRATE == "" || DISCRATE == null || DISCRATE == "null")
                {
                    prm20.Value = System.DBNull.Value;
                }
                else
                    prm20.Value = DISCRATE;
                objOraclecommand.Parameters.Add(prm20);

                OracleParameter prm21 = new OracleParameter("paddcomm", OracleType.VarChar);
                prm21.Direction = ParameterDirection.Input;
                if (addcomm == "" || addcomm == null || addcomm == "null")
                {
                    prm21.Value = System.DBNull.Value;
                }
                else
                    prm21.Value = addcomm;
                objOraclecommand.Parameters.Add(prm21);

                OracleParameter prm22 = new OracleParameter("pCHKTRADEDISC", OracleType.VarChar);
                prm22.Direction = ParameterDirection.Input;
                if (CHKTRADEDISC == "" || CHKTRADEDISC == null || CHKTRADEDISC == "null")
                {
                    prm22.Value = System.DBNull.Value;
                }
                else
                    prm22.Value = CHKTRADEDISC;
                objOraclecommand.Parameters.Add(prm22);

                OracleParameter prm23 = new OracleParameter("pTRANSLATIONPREMIUM", OracleType.VarChar);
                prm23.Direction = ParameterDirection.Input;
                if (TRANSLATIONPREMIUM == "" || TRANSLATIONPREMIUM == null || TRANSLATIONPREMIUM == "null")
                {
                    prm23.Value = System.DBNull.Value;
                }
                else
                    prm23.Value = TRANSLATIONPREMIUM;
                objOraclecommand.Parameters.Add(prm23);

                OracleParameter prm24 = new OracleParameter("pTRANSLATIONDISC", OracleType.VarChar);
                prm24.Direction = ParameterDirection.Input;
                if (TRANSLATIONDISC == "" || TRANSLATIONDISC == null || TRANSLATIONDISC == "null")
                {
                    prm24.Value = System.DBNull.Value;
                }
                else
                    prm24.Value = TRANSLATIONDISC;
                objOraclecommand.Parameters.Add(prm24);

                OracleParameter prm25 = new OracleParameter("pTRANSLATIONTYPE", OracleType.VarChar);
                prm25.Direction = ParameterDirection.Input;
                if (TRANSLATIONTYPE == "" || TRANSLATIONTYPE == null || TRANSLATIONTYPE == "null")
                {
                    prm25.Value = System.DBNull.Value;
                }
                else
                    prm25.Value = TRANSLATIONTYPE;
                objOraclecommand.Parameters.Add(prm25);

                OracleParameter prm26 = new OracleParameter("pSPECIALDISCOUNT", OracleType.VarChar);
                prm26.Direction = ParameterDirection.Input;
                if (SPECIALDISCOUNT == "" || SPECIALDISCOUNT == null || SPECIALDISCOUNT == "null")
                {
                    prm26.Value = System.DBNull.Value;
                }
                else
                    prm26.Value = SPECIALDISCOUNT;
                objOraclecommand.Parameters.Add(prm26);

                OracleParameter prm27 = new OracleParameter("pSPACEDISCOUNT", OracleType.VarChar);
                prm27.Direction = ParameterDirection.Input;
                if (SPACEDISCOUNT == "" || SPACEDISCOUNT == null || SPACEDISCOUNT == "null")
                {
                    prm27.Value = System.DBNull.Value;
                }
                else
                    prm27.Value = SPACEDISCOUNT;
                objOraclecommand.Parameters.Add(prm27);

                OracleParameter prm28 = new OracleParameter("pSPECIALCHARGES", OracleType.VarChar);
                prm28.Direction = ParameterDirection.Input;
                if (SPECIALCHARGES == "" || SPECIALCHARGES == null || SPECIALCHARGES == "null")
                {
                    prm28.Value = System.DBNull.Value;
                }
                else
                    prm28.Value = SPECIALCHARGES;
                objOraclecommand.Parameters.Add(prm28);

                OracleParameter prm29 = new OracleParameter("pPACKAGECODE", OracleType.VarChar);
                prm29.Direction = ParameterDirection.Input;
                if (PACKAGECODE == "" || PACKAGECODE == null || PACKAGECODE == "null")
                {
                    prm29.Value = System.DBNull.Value;
                }
                else
                    prm29.Value = PACKAGECODE;
                objOraclecommand.Parameters.Add(prm29);

                OracleParameter prm30 = new OracleParameter("pDISCTYPE", OracleType.VarChar);
                prm30.Direction = ParameterDirection.Input;
                if (DISCTYPE == "" || DISCTYPE == null || DISCTYPE == "null")
                {
                    prm30.Value = System.DBNull.Value;
                }
                else
                    prm30.Value = DISCTYPE;
                objOraclecommand.Parameters.Add(prm30);

                OracleParameter prm31 = new OracleParameter("pPREMPER", OracleType.VarChar);
                prm31.Direction = ParameterDirection.Input;
                if (PREMPER == "" || PREMPER == null || PREMPER == "null")
                {
                    prm31.Value = System.DBNull.Value;
                }
                else
                    prm31.Value = PREMPER;
                objOraclecommand.Parameters.Add(prm31);

                OracleParameter prm6 = new OracleParameter("pSPECIALDISCPER", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                if (SPECIALDISCPER == "" || SPECIALDISCPER == null || SPECIALDISCPER == "null")
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                    prm6.Value = SPECIALDISCPER;
                objOraclecommand.Parameters.Add(prm6);

                OracleParameter prm33 = new OracleParameter("pDISCOUNT", OracleType.VarChar);
                prm33.Direction = ParameterDirection.Input;
                if (DISCOUNT == "" || DISCOUNT == null || DISCOUNT == "null")
                {
                    prm33.Value = System.DBNull.Value;
                }
                else
                    prm33.Value = DISCOUNT;
                objOraclecommand.Parameters.Add(prm33);

                OracleParameter prm34 = new OracleParameter("pDISCOUNTPER", OracleType.VarChar);
                prm34.Direction = ParameterDirection.Input;
                if (DISCOUNTPER == "" || DISCOUNTPER == null || DISCOUNTPER == "null")
                {
                    prm34.Value = System.DBNull.Value;
                }
                else
                    prm34.Value = DISCOUNTPER;
                objOraclecommand.Parameters.Add(prm34);

                OracleParameter prm35 = new OracleParameter("pSPACEDISCPER", OracleType.VarChar);
                prm35.Direction = ParameterDirection.Input;
                if (SPACEDISCPER == "" || SPACEDISCPER == null || SPACEDISCPER == "null")
                {
                    prm35.Value = System.DBNull.Value;
                }
                else
                    prm35.Value = SPACEDISCPER;
                objOraclecommand.Parameters.Add(prm35);

                OracleParameter prm36 = new OracleParameter("pPREMIUMCHARGESTYPE", OracleType.VarChar);
                prm36.Direction = ParameterDirection.Input;
                if (PREMIUMCHARGESTYPE == "" || PREMIUMCHARGESTYPE == null || PREMIUMCHARGESTYPE == "null")
                {
                    prm36.Value = System.DBNull.Value;
                }
                else
                    prm36.Value = PREMIUMCHARGESTYPE;
                objOraclecommand.Parameters.Add(prm36);

                OracleParameter prm37 = new OracleParameter("pAGCITY", OracleType.VarChar);
                prm37.Direction = ParameterDirection.Input;
                if (AGCITY == "" || AGCITY == null || AGCITY == "null")
                {
                    prm37.Value = System.DBNull.Value;
                }
                else
                    prm37.Value = AGCITY;
                objOraclecommand.Parameters.Add(prm37);

                OracleParameter prm38 = new OracleParameter("pADTYPE", OracleType.VarChar);
                prm38.Direction = ParameterDirection.Input;
                if (ADTYPE == "" || ADTYPE == null || ADTYPE == "null")
                {
                    prm38.Value = System.DBNull.Value;
                }
                else
                    prm38.Value = ADTYPE;
                objOraclecommand.Parameters.Add(prm38);

                OracleParameter prm39 = new OracleParameter("pUOMCODE", OracleType.VarChar);
                prm39.Direction = ParameterDirection.Input;
                if (UOMCODE == "" || UOMCODE == null || UOMCODE == "null")
                {
                    prm39.Value = System.DBNull.Value;
                }
                else
                    prm39.Value = UOMCODE;
                objOraclecommand.Parameters.Add(prm39);

                OracleParameter prm40 = new OracleParameter("pTRANSLATIONCODE", OracleType.VarChar);
                prm40.Direction = ParameterDirection.Input;
                if (TRANSLATIONCODE == "" || TRANSLATIONCODE == null || TRANSLATIONCODE == "null")
                {
                    prm40.Value = System.DBNull.Value;
                }
                else
                    prm40.Value = TRANSLATIONCODE;
                objOraclecommand.Parameters.Add(prm40);

                OracleParameter prm41 = new OracleParameter("pPAGEPREM", OracleType.VarChar);
                prm41.Direction = ParameterDirection.Input;
                if (PAGEPREM == "" || PAGEPREM == null || PAGEPREM == "null")
                {
                    prm41.Value = System.DBNull.Value;
                }
                else
                    prm41.Value = PAGEPREM;
                objOraclecommand.Parameters.Add(prm41);

                OracleParameter prm42 = new OracleParameter("pPAGEPOSITIONCODE", OracleType.VarChar);
                prm42.Direction = ParameterDirection.Input;
                if (PAGEPOSITIONCODE == "" || PAGEPOSITIONCODE == null || PAGEPOSITIONCODE == "null")
                {
                    prm42.Value = System.DBNull.Value;
                }
                else
                    prm42.Value = PAGEPOSITIONCODE;
                objOraclecommand.Parameters.Add(prm42);

                OracleParameter prm43 = new OracleParameter("pPAGEAMOUNT", OracleType.VarChar);
                prm43.Direction = ParameterDirection.Input;
                if (PAGEAMOUNT == "" || PAGEAMOUNT == null || PAGEAMOUNT == "null")
                {
                    prm43.Value = System.DBNull.Value;
                }
                else
                    prm43.Value = PAGEAMOUNT;
                objOraclecommand.Parameters.Add(prm43);

                OracleParameter prm44 = new OracleParameter("pPOSPREMDISC", OracleType.VarChar);
                prm44.Direction = ParameterDirection.Input;
                if (POSPREMDISC == "" || POSPREMDISC == null || POSPREMDISC == "null")
                {
                    prm44.Value = System.DBNull.Value;
                }
                else
                    prm44.Value = POSPREMDISC;
                objOraclecommand.Parameters.Add(prm44);

                OracleParameter prm45 = new OracleParameter("pBKDATE", OracleType.VarChar);
                prm45.Direction = ParameterDirection.Input;
                if (BKDATE == "" || BKDATE == null || BKDATE == "null")
                {
                    prm45.Value = System.DBNull.Value;
                }
                else
                    prm45.Value = Convert.ToDateTime(BKDATE).ToString("dd-MMMM-yyyy");
                objOraclecommand.Parameters.Add(prm45);



                OracleParameter prm46 = new OracleParameter("pcolorcode", OracleType.VarChar);
                prm46.Direction = ParameterDirection.Input;
                if (colorcode == "" || colorcode == null || colorcode == "null")
                {
                    prm46.Value = System.DBNull.Value;
                }
                else
                    prm46.Value = colorcode;
                objOraclecommand.Parameters.Add(prm46);

                


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

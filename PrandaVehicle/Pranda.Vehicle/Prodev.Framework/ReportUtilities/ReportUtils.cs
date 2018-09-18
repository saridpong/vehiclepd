using Microsoft.Reporting.WebForms;
using Prodev.Framework.ReportUtilities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodev.Framework.ReportUtilities
{
    public class ReportUtils
    {
        public byte[] RenderFromServer(ReportItem req)
        {
            try
            {
                ReportViewer ReportViewer1 = new ReportViewer();
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(req.ReportServerUrl);
                ReportViewer1.ServerReport.ReportPath = req.ReportPath;
                List<ReportParameter> param = new List<ReportParameter>();
                if (req.Params != null)
                {

                    foreach (ReportParameterItem item in req.Params)
                    {
                        ReportParameter pr = new ReportParameter(item.ParameterName, item.ParameterValue);
                        param.Add(pr);
                    }

                }
                IReportServerCredentials irsc = new CustomReportCredentials(req.ReportServerUserName, req.ReportServerPassword, req.ReportServerDomain);
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;

                if (req.Credencials != null)
                {
                    var cre = new DataSourceCredentials();
                    cre.Name = req.Credencials.CredencialName;
                    cre.Password = req.Credencials.CredencialPassword;
                    cre.UserId = req.Credencials.CredencialUserName;
                    ReportViewer1.ServerReport.SetDataSourceCredentials(new DataSourceCredentials[1] { cre });
                }
                ReportViewer1.ServerReport.SetParameters(param);

                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;
                deviceInfo = "True";
                byte[] bytes = ReportViewer1.ServerReport.Render(req.GetOutputFormat(), null, out mimeType, out encoding, out extension, out streamids, out warnings);
                ReportViewer1.ServerReport.Refresh();
                return bytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] RenderFromLocal(ReportItem req)
        {
            try
            {
                ReportViewer ReportViewer1 = new ReportViewer();
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = req.ReportPath;
                ReportViewer1.LocalReport.Refresh();

                foreach (ReportDataSource source in req.DataSources)
                {
                    ReportViewer1.LocalReport.DataSources.Add(source);
                }

                List<ReportParameter> param = new List<ReportParameter>();
                if (req.Params != null)
                {

                    foreach (ReportParameterItem item in req.Params)
                    {
                        ReportParameter pr = new ReportParameter(item.ParameterName, item.ParameterValue);
                        param.Add(pr);
                    }

                }
                if (param.Count > 0)
                {
                    ReportViewer1.LocalReport.SetParameters(param);
                }
                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension, deviceInfo;
                deviceInfo = "True";
                byte[] bytes = ReportViewer1.LocalReport.Render(req.GetOutputFormat(), null, out mimeType, out encoding, out extension, out streamids, out warnings);
                ReportViewer1.LocalReport.Refresh();
                return bytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

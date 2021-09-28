using System;
using System.IO;
using BusinessLogic.Enums;
using BusinessLogic.Extensions;
using HandlebarsDotNet;
using Persistence.Models;

namespace BusinessLogic.Services
{
    public class HandlebarsService : IHandlebarsService
    {
        public string InvoiceToHtml(Invoice invoice, Template templateId)
        {
            RegisterHelpers();

            string template = File.ReadAllText(templateId.ToDescription());
            var renderTemplate = Handlebars.Compile(template);
            var result = renderTemplate(invoice);

            return result;
        }

        private void RegisterHelpers()
        {
            Handlebars.RegisterHelper("formatDate", (writer, context, parameters) =>
            {
                try
                {
                    var safeDate = DateTime.Parse(parameters[0].ToString()).ToLongDateString();
                    writer.WriteSafeString(safeDate);
                }
                catch (Exception)
                {
                    writer.WriteSafeString("");
                }
            });

            Handlebars.RegisterHelper("formatCurrency", (writer, context, parameters) =>
            {
                var amount = double.Parse(parameters[0].ToString());

                // TODO: Get local currency string
                var currency = $"R {amount}";
                writer.WriteSafeString(currency);
            });

            Handlebars.RegisterHelper("multiply", (writer, context, parameters) =>
            {
                var first = double.Parse(parameters[0].ToString());
                var second = double.Parse(parameters[1].ToString());

                // TODO: Get local currency stringÒ
                var total = $"R {(double)first * (double)second}";
                writer.WriteSafeString(total);
            });
        }
    }
}
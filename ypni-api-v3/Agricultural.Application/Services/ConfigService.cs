using Agricultural.Application.DTOs.Config;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Services;
using Agricultural.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Services
{
    public class ConfigService : IConfigService
    {
        public async Task<IResult<ConfigDTO>> GetConfig(CancellationToken cancellationToken = default)
        {

            var configDTO = new ConfigDTO {
                company_logo = "https:/baseurl/2022-04-20-625fa32105ddf.png",
                maintenance_mode = false,
                currency_model = "multi_currency",
                system_default_currency = 1,
                currency_symbol_position = "right",
                decimal_point_settings = 1,
                country_code = "US",
                software_version = "12.2",
              
            };


            var lang = new List<Language>();
            lang.Add(new Language { code = "en", name = "english" });
            lang.Add(new Language { code = "sa", name = "Arabic" });

            var currncy = new List<CurrencyList>();
            currncy.Add(new CurrencyList {
                id = 1,
                name = "Yemen",
                symbol = "YER",
                code = "YER",
                exchange_rate = 1,
                status = 1,
                created_at = "2021-06-27T20:39:37.000000Z",
                updated_at = "2021-06-27T20:39:37.000000Z"

            });
            var color = new List<Color>();
            color.Add(new Color
            {
                id = 1,
                name = "IndianRed",
                code = "#CD5C5C",
                created_at = "2021-06-27T20:39:37.000000Z",
                updated_at = "2021-06-27T20:39:37.000000Z"
            });
            var unitT = new List<string>();
            unitT.Add("kg"); unitT.Add("pc");
            var BASURL=new BaseUrls{


                product_image_url = "https://localhost:7264",
                product_thumbnail_url = "https://localhost:7264",
                digital_product_url = "https://localhost:7264",
                brand_image_url = "https://localhost:7264",
                customer_image_url = "https://localhost:7264",
                banner_image_url = "https://localhost:7264",
                category_image_url = "https://localhost:7264",
                review_image_url = "https://localhost:7264",
                seller_image_url = "https://localhost:7264",
                shop_image_url = "https://localhost:7264",
                notification_image_url = "https://localhost:7264",
                delivery_man_image_url = "https://localhost:7264",
                uploud_image_url = "https://localhost:7264",

                //product_image_url = "http://ypniweb.quantum-ye.com",
                //product_thumbnail_url = "http://ypniweb.quantum-ye.com",
                //digital_product_url = "http://ypniweb.quantum-ye.com",
                //brand_image_url = "http://ypniweb.quantum-ye.com",
                //customer_image_url = "http://ypniweb.quantum-ye.com",
                //banner_image_url = "http://ypniweb.quantum-ye.com",
                //category_image_url = "http://ypniweb.quantum-ye.com",
                //review_image_url = "http://ypniweb.quantum-ye.com",
                //seller_image_url = "http://ypniweb.quantum-ye.com",
                //shop_image_url = "http://ypniweb.quantum-ye.com",
                //notification_image_url = "http://ypniweb.quantum-ye.com",
                //delivery_man_image_url = "http://ypniweb.quantum-ye.com",
                //uploud_image_url = "http://ypniweb.quantum-ye.com",

            };

           
            configDTO.base_urls = BASURL;
            configDTO.colors = color;
            configDTO.unit=unitT;
            configDTO.currency_list = currncy;
            configDTO.language = lang;
            return   await Result<ConfigDTO>.SuccessAsync(configDTO, "");
        }

    }
}

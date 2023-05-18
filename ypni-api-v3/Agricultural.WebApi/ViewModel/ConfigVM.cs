namespace Agricultural.WebApi.ViewModel
{







    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BaseUrls
    {
        public string product_image_url { get; set; }
        public string product_thumbnail_url { get; set; }
        public string digital_product_url { get; set; }
        public string brand_image_url { get; set; }
        public string customer_image_url { get; set; }
        public string banner_image_url { get; set; }
        public string category_image_url { get; set; }
        public string review_image_url { get; set; }
        public string seller_image_url { get; set; }
        public string shop_image_url { get; set; }
        public string notification_image_url { get; set; }
        public string delivery_man_image_url { get; set; }
    }

    public class Color
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class CurrencyList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string code { get; set; }
        public int exchange_rate { get; set; }
        public int status { get; set; }
        public object created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class ConfigVM

    {
        public string company_logo { get; set; }
        public bool maintenance_mode { get; set; }
        public string currency_model { get; set; }
        public bool digital_payment { get; set; }
        public bool cash_on_delivery { get; set; }
        public int system_default_currency { get; set; }
        public string currency_symbol_position { get; set; }
        public int decimal_point_settings { get; set; }
        public string country_code { get; set; }
        public List<Language> language { get; set; }
        public List<CurrencyList> currency_list { get; set; }
        public List<Color> colors { get; set; }
        public List<string> unit { get; set; }
        public string software_version { get; set; }
        public BaseUrls base_urls { get; set; }
    }



}

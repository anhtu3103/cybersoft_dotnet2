using System.Text.Json;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //define function call API get list product
    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("Product");
            Console.WriteLine("API response " + response);

            var jsonDoc = JsonDocument.Parse(response);

            // xử lí dữ liệu
            // nếu API trả về object có chứa field "content"
            if (jsonDoc.RootElement.TryGetProperty("content", out JsonElement content))
            {
                // PropertyNameInsensitive: Không phân biệt hoa thường của key dữ liệu vd data trả "name" : "" sẽ tự map vào key Name của object
                return JsonSerializer.Deserialize<List<Product>>(content.GetRawText(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            }
            else
                return new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new List<Product>();
        }
    }
}
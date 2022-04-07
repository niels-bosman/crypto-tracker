using System.Net.Http.Headers;
using CryptoList.DTO;
using CryptoList.Models;

namespace CryptoList.Services;

public class OpenAIService
{
    private const string ApiBaseUrl = "https://api.openai.com/v1/engines/text-davinci-002/completions";
    private static readonly HttpClient Http = new();

    public OpenAIService()
    {
        Http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "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");
        
        Http.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public static async Task<string?> SummarizeText(OpenAISummarizeDTO openAiSummarizeDto)
    {
        var response = await Http.PostAsJsonAsync(ApiBaseUrl, openAiSummarizeDto);
        var openai = await response.Content.ReadFromJsonAsync<OpenAI>();
        
        return openai?.choices[0].text;
    }
}
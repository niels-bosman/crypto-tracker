namespace CryptoList.DTO;

public class OpenAISummarizeDTO
{
    public OpenAISummarizeDTO(string prompt)
    {
        this.prompt = prompt;
    }
    
    private string _prompt;
    public string prompt
    {
        get => _prompt;
        set => _prompt = $"Summarize this for a second-grade student:\n\n {value}";
    }

    public double temperature { get; set; } = 0.7;
    public int max_tokens { get; set; } = 80;
    public double top_p { get; set; } = 1.0;
    public double frequency_penalty { get; set; } = 0.0;
    public double presence_penalty { get; set; } = 0.0;
}
namespace Serialization.Dtos.ResponseDto;

public class ResultDto
{
    public string Message { get; set; } = "successfull";
    public bool Success { get; set; } = true;
    public int StatusCode { get; set; } = 200;


    public ResultDto(string message)
    {
        Message = message;
    }

    public ResultDto(string message, bool success)
    {
        Message = message;
        Success = success;
    }
    public ResultDto(string message, int statusCode, bool success)
    {
        Message = message;
        StatusCode = statusCode;
        Success = success;
    }

}

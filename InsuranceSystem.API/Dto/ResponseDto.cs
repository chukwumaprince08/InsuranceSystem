namespace InsuranceSystem.API.Dto
{
    public class ResponseDto
    {

        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "Successful";
        public List<string> ErrorMessages { get; set; }

    }
}


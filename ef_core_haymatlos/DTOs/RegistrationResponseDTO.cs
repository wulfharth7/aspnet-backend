namespace ef_core_haymatlos.DTOs
{
    public class RegistrationResponseDTO
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}

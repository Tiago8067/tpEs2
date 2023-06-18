namespace BusinessLogic.Entities;

public partial class Loginresult
{
    public bool? Successful { get; set; }

    public string? Error { get; set; }

    public string? Token { get; set; }
}

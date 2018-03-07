using Fake_Code_Analysis_Implementation_5_03.Utils.PropsHelper;

namespace Fake_Code_Analysis_Implementation_5_03.Models
{
    public class CodeFile
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string RawCode { get; set; }
        public ProgramLanguage ProgramLanguage { get; set;}
    }
}
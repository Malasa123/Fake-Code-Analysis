using Fake_Code_Analysis_Implementation_5_03.Models;
using Fake_Code_Analysis_Implementation_5_03.Utils.PropsHelper;
namespace Fake_Code_Analysis_Implementation_5_03.Utils.ScanServices
{
    public class Scan
    {

        public bool  IsFileTypeFits(CodeFile File)
        {
            bool IsValidFile;
            switch (File.ProgramLanguage)
            {
                case ProgramLanguage.Java:
                    IsValidFile = RunJavaCheck(File);
                    break;
                case ProgramLanguage.Javascript:
                    IsValidFile = RunJavaScriptCheck(File);
                    break;
                case ProgramLanguage.C_Sharp:
                    IsValidFile = true;
                    break;
                case ProgramLanguage.Python:
                    IsValidFile = true;
                    break;
                case ProgramLanguage.Swift:
                    IsValidFile = true;
                    break;
                case ProgramLanguage.TypeScript:
                    IsValidFile = true;
                    break;
                default:
                    IsValidFile = false;
                    break;
            }
            return IsValidFile;
        }

        private bool RunJavaScriptCheck(CodeFile file)
        {
            if (file.RawCode.Contains("static") ||
                file.RawCode.Contains("ecstatic") ||
                file.RawCode.Contains("fantastic"))
            {
                return false;
            }

            return true;

        }

        private bool RunJavaCheck(CodeFile file)
        {
            if (file.RawCode.Contains("script") ||
                file.RawCode.Contains("var") ||
                file.RawCode.Contains("stat"))
            {
                return false;
            }

            return true;
        }
    }
}
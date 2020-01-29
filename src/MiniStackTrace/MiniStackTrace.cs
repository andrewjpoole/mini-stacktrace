using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MiniStackTrace
{
    public class MiniStackTrace
    {
        public static string Get()
        {
            var trace = new MiniStackTrace();
            return trace.Get();
        }

        public string Get(int maxDepth = 2, bool retrieveFileLineInfo = true, bool fileLineInfoOnLastFrameOnly = true, int numberOfCallsToIgnore = 2)
        {
            if (maxDepth < 1)
                return string.Empty;

            var stackTrace = new StackTrace(retrieveFileLineInfo);
            StackFrame[] stackFrames = stackTrace.GetFrames();

            var sb = new StringBuilder();
            var firstStack = true;
            
            var stackCountCheck = maxDepth + numberOfCallsToIgnore;
            var startingIndex = stackFrames.Count() > stackCountCheck ? stackCountCheck : stackFrames.Count();
            startingIndex = startingIndex - 1; // deal with zero offset
            for (int i = startingIndex; i >= numberOfCallsToIgnore; i--)
            {
                var stackFrame = stackFrames[i];
                var method = stackFrame.GetMethod();

                sb.Append(firstStack ? "" : "|");

                if (retrieveFileLineInfo)
                {
                    if (!fileLineInfoOnLastFrameOnly || (fileLineInfoOnLastFrameOnly && i == numberOfCallsToIgnore))
                    {
                        var fileName = stackFrame.GetFileName().Split("\\").LastOrDefault();
                        var lineNumber = stackFrame.GetFileLineNumber();
                        sb.Append($"[{fileName}:{lineNumber}]");
                    }
                }

                sb.Append($"{method.DeclaringType.Name}.{method.Name}()");
                firstStack = false;
            }           

            return sb.ToString();
        }
    }
}

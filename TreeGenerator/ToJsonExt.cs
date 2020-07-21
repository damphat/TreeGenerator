using System.Collections;
using System.Text;

namespace TreeGenerator {
    /// <summary>
    /// Convert dictionaries and enumerable objects to json-like string
    /// </summary>
    public static class ToJsonExt { 
        private static StringBuilder WriteIndent(StringBuilder sb, int indent, int indentLevel) {
            sb.AppendLine();
            return sb.Append(' ', indentLevel * indent);
        }

        private static StringBuilder WriteObject(StringBuilder sb, IDictionary dict, int indent, int indentLevel) {
            if (dict.Count == 0) indent = 0;
            sb.Append("{");
            var first = true;

            foreach (DictionaryEntry e in dict) {
                if (indent > 0) WriteIndent(sb, indent, indentLevel + 1);
                else if (first) first = false; else sb.Append(',');

                sb.Append(e.Key);
                sb.Append(": ");
                Write(sb, e.Value, indent, indentLevel + 1);
            }
            if(indent>0) WriteIndent(sb, indent, indentLevel);
            sb.Append("}");
            return sb;
        }

        private static StringBuilder WriteArray(StringBuilder sb, IEnumerable list, int indent, int indentLevel) {
            if (list is ICollection col && col.Count == 0) indent = 0;
            sb.Append("[");
            var first = true;
            foreach (var e in list) {
                if (indent > 0)
                    WriteIndent(sb, indent, indentLevel + 1);
                else {
                    if (first) first = false; else  sb.Append(',');
                }
                Write(sb, e, indent, indentLevel + 1);
            }
            if(indent > 0) WriteIndent(sb, indent, indentLevel);
            sb.Append("]");
            return sb;
        }

        private static StringBuilder Write(StringBuilder sb, object o, int indent, int indentLevel) {

            switch (o) {
                case null: return sb.Append("null");
                case bool b: return sb.Append(b ? "true" : "false");
                case string s: return sb.Append(s);
                case IDictionary dict: return WriteObject(sb, dict, indent, indentLevel);
                case IEnumerable list: return WriteArray(sb, list, indent, indentLevel);
                default: return sb.Append(o);
            }
            
        }

        public static string ToJson(this object o, int indent = 2) {
            return Write(new StringBuilder(), o, indent, 0).ToString();
        }
    }
}

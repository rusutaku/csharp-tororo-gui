using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;

using Microsoft.Scripting.Hosting;
using IronRuby;
using IronRuby.Builtins;

namespace tororo_gui
{

    public class IronRubyScriptEngine
    {
        ScriptRuntime _runtime;
        ScriptEngine  _engine;
        ScriptScope   _scope;

        public IronRubyScriptEngine()
        {
            LoadRequiredAssemblies();
            _runtime = Ruby.CreateRuntime();
            _engine = Ruby.GetEngine(_runtime);             
            ResetScope();
        }

        /// <summary>
        /// We need the assembly loaded into memory before CreateRuntime() is called, so we force it here.
        /// </summary>

        private static void LoadRequiredAssemblies()
        {
            ClrString.IsEmpty("");
        }

        /// <summary>
        /// Resets the scope, allowing you to run the same script against multiple inputs.
        /// </summary>

        public void ResetScope()
        {
            _scope = _engine.CreateScope();
        }

        public IronRubyScriptEngine SetParameter(string parameterName, object value)
        {
            _scope.SetVariable(parameterName, value);
            return this;
        }

        public object Invoke(string script)
        {
            //string expression = string.Format("Proc.new {{ |{0}| {1} }}", variableNames, script);
            var proc = _engine.Execute(script, _scope);
            return proc;
        }

        public void ExecuteFile(string file)
        {
            _engine.ExecuteFile(file, _scope);
        }
    }
}
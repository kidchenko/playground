using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;

namespace ConsoleApplication
{
	public class NavitaireVisitor : CSharpSyntaxRewriter
	{
		//public override SyntaxNode VisitUsingStatement(UsingStatementSyntax node)
		//{
		//	return base.VisitUsingStatement(node);
		//}

		//public override SyntaxNode VisitUsingDirective(UsingDirectiveSyntax node)
		//{
		//	return base.VisitUsingDirective(node);
		//}

		public override SyntaxNode VisitCompilationUnit(CompilationUnitSyntax node)
		{
			var names = node.Usings.Select(x => x.Name.ToString());

			var navitaire = "Juca";
			return base.VisitCompilationUnit(node);
		}

		public override 
	}


    public class Program
    {
        public static void Main(string[] args)
        {
            var pathToLookup = args.FirstOrDefault() ?? @"/Users/josebarbosa/thoughtworks/EmployeeReport/EmployeeReport.Web/Data";
            var files = Directory.GetFiles(pathToLookup, "*.cs", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var dirtyCode = CSharpSyntaxTree.ParseText(File.ReadAllText(file)).GetRoot();
                var cleanCode = new NavitaireVisitor().Visit(dirtyCode);
                File.WriteAllText(file, cleanCode.ToFullString(), Encoding.UTF8);
            }
        }
    }
}

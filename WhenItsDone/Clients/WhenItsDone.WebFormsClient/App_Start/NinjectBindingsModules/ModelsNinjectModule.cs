﻿using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Modules;

using WhenItsDone.Models.AssemblyId;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.ConfigureFactoriesConventionBinding);
        }

        private void ConfigureFactoriesConventionBinding(IFromSyntax bindingSyntax)
        {
            bindingSyntax
                .FromAssemblyContaining<IModelsAssemblyId>()
                .SelectAllInterfaces()
                .EndingWith("Factory")
                .BindToFactory()
                .Configure(binding => binding.InSingletonScope());
        }
    }
}
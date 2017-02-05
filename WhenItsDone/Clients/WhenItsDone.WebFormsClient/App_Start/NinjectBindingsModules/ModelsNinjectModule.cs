﻿using System.Linq;

using Bytes2you.Validation;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Extensions.Factory;
using Ninject.Modules;

using WhenItsDone.Models;
using WhenItsDone.Models.AssemblyId;
using WhenItsDone.Models.Factories;

namespace WhenItsDone.WebFormsClient.App_Start.NinjectBindingsModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(this.ConfigureFactoriesConventionBinding);

            this.Bind<User>().ToSelf().NamedLikeFactoryMethod((ICompleteUserFactory factory) => factory.GetUser());
            this.Bind<User>().ToMethod(this.GetInitializedUserFactoryMethod).NamedLikeFactoryMethod((IInitializedUserFactory factory) => factory.GetInitializedUser(null));
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

        private User GetInitializedUserFactoryMethod(IContext context)
        {
            var methodParameter = context.Parameters.FirstOrDefault();
            var username = (string)methodParameter?.GetValue(context, null);
            Guard.WhenArgument(username, nameof(username)).IsNullOrEmpty();

            var completeUserFactory = context.Kernel.Get<ICompleteUserFactory>();
            var nextUser = completeUserFactory.GetUser();
            nextUser.Client = completeUserFactory.CreateClient();
            nextUser.Worker = completeUserFactory.CreateWorker();
            nextUser.MedicalInformation = completeUserFactory.CreateMedicalInformation();
            nextUser.ContactInformation = completeUserFactory.CreateContactInformation();

            nextUser.ContactInformation.Email = username;
            nextUser.Username = username;

            return nextUser;
        }
    }
}
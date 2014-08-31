using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentArchitecture.DependencyInjection;
using Microsoft.Practices.ServiceLocation;

namespace FluentArchitecture.Web.Infrastructure
{
	public abstract class FluentHttpApplication<TRegistrationContext, TRegistration> : HttpApplication
		where TRegistrationContext : IDependencyInjectionRegistrationContext<TRegistration>, new()
		where TRegistration : class
	{
		#region Initialization

		private readonly TRegistrationContext _registrationContext;
		private IServiceLocator _serviceLocator;

		private readonly List<Type> _startupTasks;

		private readonly List<Type> _afterStartupTasks;
		private readonly List<Type> _beginRequestTasks;
		private readonly List<Type> _authenticateRequestTasks;
		private readonly List<Type> _authorizeRequestTasks;
		private readonly List<Type> _resolveRequestCacheTasks;
		private readonly List<Type> _sessionStartTasks;
		private readonly List<Type> _acquireRequestStateTasks;
		private readonly List<Type> _preRequestHandlerExecuteTasks;
		private readonly List<Type> _postRequestHandlerExecuteTasks;
		private readonly List<Type> _releaseRequestStateTasks;
		private readonly List<Type> _updateRequestCacheTasks;
		private readonly List<Type> _endRequestTasks;
		private readonly List<Type> _preSendRequestHeadersTasks;
		private readonly List<Type> _preSendRequestContentTasks;
		private readonly List<Type> _sessionEndTasks;
		private readonly List<Type> _disposalTasks;
		private readonly List<Type> _shutdownTasks;

		protected FluentHttpApplication()
		{
			_registrationContext = new TRegistrationContext();

			_startupTasks = new List<Type>();

			_afterStartupTasks = new List<Type>();
			_beginRequestTasks = new List<Type>();
			_authenticateRequestTasks = new List<Type>();
			_authorizeRequestTasks = new List<Type>();
			_resolveRequestCacheTasks = new List<Type>();
			_sessionStartTasks = new List<Type>();
			_acquireRequestStateTasks = new List<Type>();
			_preRequestHandlerExecuteTasks = new List<Type>();
			_postRequestHandlerExecuteTasks = new List<Type>();
			_releaseRequestStateTasks = new List<Type>();
			_updateRequestCacheTasks = new List<Type>();
			_endRequestTasks = new List<Type>();
			_preSendRequestHeadersTasks = new List<Type>();
			_preSendRequestContentTasks = new List<Type>();
			_sessionEndTasks = new List<Type>();
			_disposalTasks = new List<Type>();
			_shutdownTasks = new List<Type>();
		}

		#endregion

		#region Task registration methods

		public FluentHttpApplication<TRegistrationContext, TRegistration> StartupTask<T>() where T : IWebRegistrationTask<TRegistration>
		{
			_startupTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> AfterStartupTask<T>() where T : IWebTask
		{
			_afterStartupTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> BeginRequestTask<T>() where T : IWebTask
		{
			_beginRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> AuthenticateRequestTask<T>() where T : IWebTask
		{
			_authenticateRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> AuthorizeRequestTask<T>() where T : IWebTask
		{
			_authorizeRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> ResolveRequestCacheTask<T>() where T : IWebTask
		{
			_resolveRequestCacheTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> SessionStartTask<T>() where T : IWebTask
		{
			_sessionStartTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> AcquireRequestStateTask<T>() where T : IWebTask
		{
			_acquireRequestStateTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> PreRequestHandlerExecuteTask<T>() where T : IWebTask
		{
			_preRequestHandlerExecuteTasks.Add(typeof (T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> PostRequestHandlerExecuteTasks<T>() where T : IWebTask
		{
			_postRequestHandlerExecuteTasks.Add(typeof (T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> ReleaseRequestStateTask<T>() where T : IWebTask
		{
			_releaseRequestStateTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> UpdateRequestCacheTask<T>() where T : IWebTask
		{
			_updateRequestCacheTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> EndRequestTask<T>() where T : IWebTask
		{
			_endRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> PreSendRequestHeadersTask<T>() where T : IWebTask
		{
			_preSendRequestHeadersTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> PreSendRequestContentTask<T>() where T : IWebTask
		{
			_preSendRequestContentTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> SessionEndTask<T>() where T : IWebTask
		{
			_sessionEndTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> DisposalTask<T>() where T : IWebTask
		{
			_disposalTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TRegistration> ShutdownTasks<T>() where T : IWebTask
		{
			_shutdownTasks.Add(typeof(T));
			return this;
		}

		#endregion

		protected void Application_Start(object sender, EventArgs e)
		{
			foreach (IWebRegistrationTask<TRegistration> startupTask in _startupTasks.Select(startupTaskType => Activator.CreateInstance(startupTaskType) as IWebRegistrationTask<TRegistration>))
			{
				startupTask.Run(_registrationContext);
			}
			RegisterResolutionTasksList(_beginRequestTasks);
			RegisterResolutionTasksList(_afterStartupTasks);
			RegisterResolutionTasksList(_authenticateRequestTasks);

			_serviceLocator = _registrationContext.Build();
			ServiceLocator.SetLocatorProvider(() => _serviceLocator);

			RunResolutionTasksList(_afterStartupTasks);
		}

		#region Events

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			RunResolutionTasksList(_beginRequestTasks);
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
			RunResolutionTasksList(_authenticateRequestTasks);
		}

		protected void Application_AuthorizeRequest(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_authorizeRequestTasks);
		}

		protected void Application_ResolveRequestCache(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_resolveRequestCacheTasks);
		}

		protected void Session_Start(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_sessionStartTasks);
		}

		protected void Application_AcquireRequestState(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_acquireRequestStateTasks);
		}

		protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_preRequestHandlerExecuteTasks);
		}

		protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_postRequestHandlerExecuteTasks);
		}

		protected void Application_ReleaseRequestState(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_releaseRequestStateTasks);
		}

		protected void Application_UpdateRequestCache(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_updateRequestCacheTasks);
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_endRequestTasks);
		}

		protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_preSendRequestHeadersTasks);
		}

		protected void Application_PreSendRequestContent(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_preSendRequestContentTasks);
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_sessionEndTasks);
		}

		protected void Application_Disposed(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_disposalTasks);
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			RunResolutionTasksList(_shutdownTasks);
		}

		#endregion

		private void RegisterResolutionTasksList(IEnumerable<Type> list)
		{
			foreach (Type taskType in list)
			{
				_registrationContext.Register(taskType);
			}
		}

		private void RunResolutionTasksList(IEnumerable<Type> list)
		{
			foreach (IWebTask resolutionTask in list.Select(afterStartupTaskType => _serviceLocator.GetInstance(afterStartupTaskType)))
			{
				resolutionTask.Run();
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentArchitecture.DependencyInjection;

namespace FluentArchitecture.Web.Infrastructure
{
	public abstract class FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> : HttpApplication
		where TRegistrationContext : IDependencyInjectionRegistrationContext<TRegistration>, new()
		where TResolutionContext : class, IDependencyInjectionResolutionContext<TContainer>
		where TRegistration : class
		where TContainer : class
	{
		#region Initialization

		private readonly TRegistrationContext _registrationContext;
		private TResolutionContext _resolutionContext;

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

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> StartupTask<T>() where T : IRegistrationTask<TRegistration>
		{
			_startupTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> AfterStartupTask<T>() where T : IResolutionTask<TContainer>
		{
			_afterStartupTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> BeginRequestTask<T>() where T : IResolutionTask<TContainer>
		{
			_beginRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> AuthenticateRequestTask<T>() where T : IResolutionTask<TContainer>
		{
			_authenticateRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> AuthorizeRequestTask<T>() where T : IResolutionTask<TContainer>
		{
			_authorizeRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> ResolveRequestCacheTask<T>() where T : IResolutionTask<TContainer>
		{
			_resolveRequestCacheTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> SessionStartTask<T>() where T : IResolutionTask<TContainer>
		{
			_sessionStartTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> AcquireRequestStateTask<T>() where T : IResolutionTask<TContainer>
		{
			_acquireRequestStateTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> PreRequestHandlerExecuteTask<T>() where T : IResolutionTask<TContainer>
		{
			_preRequestHandlerExecuteTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> PostRequestHandlerExecuteTasks<T>() where T : IResolutionTask<TContainer>
		{
			_postRequestHandlerExecuteTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> ReleaseRequestStateTask<T>() where T : IResolutionTask<TContainer>
		{
			_releaseRequestStateTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> UpdateRequestCacheTask<T>() where T : IResolutionTask<TContainer>
		{
			_updateRequestCacheTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> EndRequestTask<T>() where T : IResolutionTask<TContainer>
		{
			_endRequestTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> PreSendRequestHeadersTask<T>() where T : IResolutionTask<TContainer>
		{
			_preSendRequestHeadersTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> PreSendRequestContentTask<T>() where T : IResolutionTask<TContainer>
		{
			_preSendRequestContentTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> SessionEndTask<T>() where T : IResolutionTask<TContainer>
		{
			_sessionEndTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> DisposalTask<T>() where T : IResolutionTask<TContainer>
		{
			_disposalTasks.Add(typeof(T));
			return this;
		}

		public FluentHttpApplication<TRegistrationContext, TResolutionContext, TRegistration, TContainer> ShutdownTasks<T>() where T : IResolutionTask<TContainer>
		{
			_shutdownTasks.Add(typeof(T));
			return this;
		}

		#endregion

		protected void Application_Start(object sender, EventArgs e)
		{
			foreach (IRegistrationTask<TRegistration> startupTask in _startupTasks.Select(startupTaskType => Activator.CreateInstance(startupTaskType) as IRegistrationTask<TRegistration>))
			{
				startupTask.Run(_registrationContext);
			}
			RegisterResolutionTasksList(_beginRequestTasks);
			RegisterResolutionTasksList(_afterStartupTasks);
			RegisterResolutionTasksList(_authenticateRequestTasks);

			_resolutionContext = (TResolutionContext) _registrationContext.Build<TContainer>();
			//DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

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
			foreach (IResolutionTask<TContainer> resolutionTask in list.Select(afterStartupTaskType => _resolutionContext.Resolve(afterStartupTaskType)))
			{
				resolutionTask.Run(_resolutionContext);
			}
		}
	}
}
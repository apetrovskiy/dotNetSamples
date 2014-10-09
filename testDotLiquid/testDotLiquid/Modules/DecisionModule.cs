
namespace testDotLiquid
{
	using System;
	using Nancy;
	using Nancy.ModelBinding;

	public class DecisionModule : NancyModule
	{
		public DecisionModule () : base("/control")
		{
			Put ["/"] = _AppDomain => {
				var command = this.Bind<Command>();
				switch (command.ControlCommand) {
				case ControlCommands.Off:
					StaticControl.On = false;
					break;
				case ControlCommands.On:
					StaticControl.On = true;
					break;
				}
				return HttpStatusCode.OK;
			};

			Get ["/report.htm"] = _ => {
				return View["report.htm", new StaticControl()];
			};
		}
	}
}


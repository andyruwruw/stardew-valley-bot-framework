using System;
using BotFramework.Behaviors;
using StardewValley;
using System.Collections.Generic;
using BotFramework.Controllers;
using BotFramework.Exceptions;
using BotFramework.Framework.States;
using StardewModdingAPI;

namespace BotFramework
{
  abstract class Bot : IBot, IEquatable<Bot>
	{
		protected TriggerType _trigger;

		protected IController _controller;

		protected IList<IState> _states;

		protected bool _isRunning;

		public Bot(
			Character character,
			TriggerType trigger,
			IList<IState> states)
		{
			if (character == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(character);

			_states = states;
			CheckStates();

			_trigger = trigger;

			BotManager.Attatch(this);
			_isRunning = _trigger == TriggerType.AlwaysOn;
		}

		public Bot(Character character, TriggerType trigger)
		{
			if (character == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(character);

			_states = DefaultStates();
			CheckStates();

			_trigger = trigger;

			BotManager.Attatch(this);
			_isRunning = _trigger == TriggerType.AlwaysOn;
		}

		public Bot(Character character)
		{
			if (character == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(character);

			_states = DefaultStates();
			CheckStates();

			_trigger = DefaultTrigger();

			BotManager.Attatch(this);
			_isRunning = _trigger == TriggerType.AlwaysOn;
		}

		public Bot()
		{
			if (DefaultCharacter() == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(DefaultCharacter());

			_states = DefaultStates();
			CheckStates();

			_trigger = DefaultTrigger();

			BotManager.Attatch(this);
			_isRunning = _trigger == TriggerType.AlwaysOn;
		}

		~Bot()
		{
			BotManager.Detatch(this);
		}

		public void Start() {
			_isRunning = true;
		}

		public void Stop() {
			_isRunning = false;
		}

		protected virtual Boolean ConditionalStart() {
			return false;
		}

		public void UpdateTicked()
		{
			if (!_isRunning
				&& _trigger == TriggerType.Conditional
				&& ConditionalStart()) {
				Start();
			}
		}

		public void DayStarted()
		{

		}

		public void ButtonPressed(SButton button)
		{
			if (!_isRunning
				&& _trigger == TriggerType.UserInput
				&& button == DefaultTriggerButton()) {
				Start();
			}
		}

		public void Warped()
		{

		}

		protected virtual TriggerType DefaultTrigger() {
			return TriggerType.Called;
		}

		protected virtual SButton DefaultTriggerButton() {
			return SButton.None;
		}

		protected virtual IController DefaultController(Character character)
		{
			return new Controller(character);
		}

		protected abstract Character DefaultCharacter();

		protected abstract IList<IState> DefaultStates();

		protected void CheckStates()
		{
			for (int i = 0; i < _states.Count; i++)
			{
				if (_states.IndexOf(_states[i]) != i)
				{
					throw new DuplicateStateException(GetId(), _states[i]);
				}
			}
		}

		public abstract string GetId();

		public virtual string GetDescription()
		{
			return "No description provided.";
		}

		public virtual IController GetController()
		{
			return _controller;
		}

		public virtual Character GetCharacter()
		{
			return _controller.GetCharacter();
		}

		public virtual IList<IState> GetStates()
		{
			return _states;
		}

		public virtual bool Equals(Bot other)
		{
			return GetId() == other.GetId();
		}
	}
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Move.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Move.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Move.
    /// </summary>
    public class Move
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Move(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent JumpEvent = delegate { };

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent MovementEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player moves.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnMove(Message m)
        {
            // Extract data.
            double xLocation = m.GetDouble(1), 
                   yLocation = m.GetDouble(2), 
                   horizontalSpeed = m.GetDouble(3), 
                   verticalSpeed = m.GetDouble(4);

            int id = m.GetInteger(0), 
                horizontalModifier = m.GetInteger(5), 
                verticalModifier = m.GetInteger(6), 
                horizontalDirection = m.GetInteger(7), 
                verticalDirection = m.GetInteger(8);

            bool hasGravityModifier = m.GetBoolean(10), spaceDown = m.GetBoolean(11);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._in.Source);

            subject.IsHoldingSpace = false;
            if (spaceDown)
            {
                subject.IsHoldingSpace = true;

                // If they are simply switching between keys whilst holding space, ignore it
                if (subject.Vertical == verticalDirection && subject.Horizontal == horizontalDirection)
                {
                    // Fire the jump event.
                    var jumpEventArgs = new PlayerEventArgs(subject, this._in.Source, m);

                    this._in.Source.Pull.Move.JumpEvent(jumpEventArgs);
                }
            }

            subject.X = xLocation;
            subject.Y = yLocation;

            subject.speedX = horizontalSpeed;
            subject.speedY = verticalSpeed;

            subject.modifierX = horizontalModifier;
            subject.modifierY = verticalModifier;

            subject.Horizontal = horizontalDirection;
            subject.Vertical = verticalDirection;

            subject.HasGravityModifier = hasGravityModifier;

            subject.IsHoldingUp = verticalDirection == -1;

            subject.IsHoldingDown = verticalDirection == 1;

            subject.IsHoldingLeft = horizontalDirection == -1;

            subject.IsHoldingRight = horizontalDirection == 1;

            // Fire the event.
            var movementEventArgs = new PlayerEventArgs(subject, this._in.Source, m);

            this._in.Source.Pull.Move.MovementEvent(movementEventArgs);
        }

        #endregion
    }
}
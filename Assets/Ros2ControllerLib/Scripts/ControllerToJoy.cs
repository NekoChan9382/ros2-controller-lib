using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ROS2;

namespace Ros2ControllerLib
{
  public enum JoyAxis
  {
    LeftStickX = 0,
    LeftStickY = 1,
    RightStickX = 2,
    RightStickY = 3,
    L2 = 4,
    R2 = 5,
  }

  public enum JoyButton
  {
    Circle = 0,
    Cross = 1,
    Square = 2,
    Triangle = 3,
    Up = 4,
    Down = 5,
    Left = 6,
    Right = 7,
    L1 = 8,
    R1 = 9,
    L3 = 10,
    R3 = 11,
    Share = 12,
    Options = 13
  }
  public class ControllerToJoy
  {
    /// <summary>
    /// Converts a Gamepad input to a ROS2 Joy message.
    /// </summary>
    /// <param name="gamepad">The Gamepad input to convert.</param>
    /// <returns>A ROS2 Joy message representing the Gamepad input.</returns>
  public sensor_msgs.msg.Joy ConvertControllerToJoy(Gamepad gamepad)
  {
    var joyMsg = new sensor_msgs.msg.Joy();
    if (gamepad == null)
    {
      return joyMsg; // Return an empty Joy message if no gamepad is connected
    }

    joyMsg.Axes[(int)JoyAxis.LeftStickX]  = gamepad.leftStick.x.ReadValue();
    joyMsg.Axes[(int)JoyAxis.LeftStickY]  = gamepad.leftStick.y.ReadValue();
    joyMsg.Axes[(int)JoyAxis.RightStickX] = gamepad.rightStick.x.ReadValue();
    joyMsg.Axes[(int)JoyAxis.RightStickY] = gamepad.rightStick.y.ReadValue();
    joyMsg.Axes[(int)JoyAxis.L2] = gamepad.leftTrigger.ReadValue();
    joyMsg.Axes[(int)JoyAxis.R2] = gamepad.rightTrigger.ReadValue();

    joyMsg.Buttons[(int)JoyButton.Circle] = gamepad.circleButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Cross]  = gamepad.crossButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Square]  = gamepad.squareButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Triangle] = gamepad.triangleButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Up] = gamepad.dpad.up.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Down] = gamepad.dpad.down.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Left] = gamepad.dpad.left.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Right] = gamepad.dpad.right.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.L1] = gamepad.leftShoulder.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.R1] = gamepad.rightShoulder.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.L3] = gamepad.leftStickButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.R3] = gamepad.rightStickButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Share] = gamepad.selectButton.isPressed ? 1 : 0;
    joyMsg.Buttons[(int)JoyButton.Options] = gamepad.startButton.isPressed ? 1 : 0;

    return joyMsg;
  }
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROS2;
using UnityEngine.InputSystem;
using Ros2ControllerLib;
using System;

public class JoyPublisherExample : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private IPublisher<sensor_msgs.msg.Joy> joy_pub;
    private ControllerToJoy ControllerToJoy;
    void Start()
    {
        TryGetComponent(out ros2Unity);
        ControllerToJoy = new ControllerToJoy();
    }

    void Update()
    {
        if (ros2Unity.Ok())
        {
            if (ros2Node == null)
            {
                ros2Node = ros2Unity.CreateNode("ROS2UnityJoyNode");
                joy_pub = ros2Node.CreatePublisher<sensor_msgs.msg.Joy>("joy");
            }
            var gamepad = Gamepad.current;

            sensor_msgs.msg.Joy msg = ControllerToJoy.ConvertControllerToJoy(gamepad);
            joy_pub.Publish(msg);
        }
    }
}

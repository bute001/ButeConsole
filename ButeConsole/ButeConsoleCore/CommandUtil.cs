﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ButeConsole
{
    internal class CommandUtil
    {
        public object ConvertInstance(Type type, Dictionary<string, string> param)
        {
            object instance = Activator.CreateInstance(type);

            foreach (var p in type.GetProperties())
            {
                var attr = GetCommandParamAttribute(p);
                var name = GetParamName(p, attr);

                CheckParam(attr, name, param);

                if (p.CanWrite && param.ContainsKey(name))
                {
                    var value = getValue(p.PropertyType, param[name]);

                    p.SetValue(instance, value);
                }
            }

            return instance;

        }


        private CommandParamAttribute GetCommandParamAttribute(PropertyInfo proertyInfo)
        {
            var attrs = proertyInfo.GetCustomAttributes(typeof(CommandParamAttribute), false);
            if (attrs.Length > 0)
            {
                return (CommandParamAttribute)attrs[0];
            }
            else
            {
                return null;
            }
        }

        private string GetParamName(PropertyInfo propertyInfo, CommandParamAttribute attribute)
        {
            if (attribute != null && !string.IsNullOrEmpty(attribute.Name))
            {
                return attribute.Name.ToLower();
            }
            else
            {
                return propertyInfo.Name.ToLower();
            }
        }


        private void CheckParam(CommandParamAttribute attribute, string name, Dictionary<string, string> param)
        {
            if (attribute != null)
            {
                if (attribute.Required)
                {
                    if (!param.ContainsKey(name))
                    {
                        throw new InstructionExcepton($"param {name} must input.");
                    }
                }
                if (attribute.IsNotBlank)
                {
                    if (!(param.ContainsKey(name) && param[name] != null && param[name].Length > 0))
                    {
                        throw new InstructionExcepton($"param {name} size must > 0.");
                    }
                }
            }
        }


        private object getValue(Type type, string str)
        {
            if (type == CommandConst.STRINGTYPE)
            {
                return str;
            }
            else if (type == CommandConst.DOUBLETYPE)
            {
                double value;
                if (double.TryParse(str, out value))
                {
                    return value;
                }
                else
                {
                    throw new InstructionExcepton($"{type.Name} parameter must be double");
                }
            }
            else if (type == CommandConst.FLOATTYPE)
            {
                float value;
                if (float.TryParse(str, out value))
                {
                    return value;
                }
                else
                {
                    throw new InstructionExcepton($"{type.Name} parameter must be float");
                }
            }
            else if (type == CommandConst.INTTYPE)
            {
                int value;
                if (int.TryParse(str, out value))
                {
                    return value;
                }
                else
                {
                    throw new InstructionExcepton($"{type.Name} parameter must be int");
                }
            }
            else if (type == CommandConst.GUIDTYPE)
            {
                Guid value;
                if (Guid.TryParse(str, out value))
                {
                    return value;
                }
                else
                {
                    throw new InstructionExcepton($"{type.Name} parameter must be Guid");
                }
            }
            else if (type == CommandConst.DATETIMETYPE)
            {
                DateTime value;
                if (DateTime.TryParse(str, out value))
                {
                    return value;
                }
                else
                {
                    throw new InstructionExcepton($"{type.Name} parameter must be DateTime");
                }
            }
            else if (type == CommandConst.BOOLYPE)
            {
                return true;
            }
            else
            {
                throw new InstructionExcepton($"{type.Name} property type is not support.");
            }

        }
    }
}
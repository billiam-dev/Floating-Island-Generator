﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cyotek.Data.Nbt.Serialization
{
  partial class TagWriter
  {
    /// <summary>
    /// Writes a <see cref="T:byte" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:byte" /> value to write.</param>
    protected abstract void WriteValue(byte value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:byte" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:byte" /> value to write.</param>
    public void WriteTag(string name, byte value)
    {
      this.WriteStartTag(name, TagType.Byte);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:byte" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:byte" /> value to write.</param>
    public void WriteTag(byte value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:byte" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:byte" /> values to write.</param>
    public void WriteListTag(string name, byte[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Byte, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:byte" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:byte" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<byte> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:byte" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:byte" /> values to write.</param>
    public void WriteListTag(IEnumerable<byte> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:byte" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:byte" /> values to write.</param>
    public void WriteListTag(byte[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:short" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:short" /> value to write.</param>
    protected abstract void WriteValue(short value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:short" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:short" /> value to write.</param>
    public void WriteTag(string name, short value)
    {
      this.WriteStartTag(name, TagType.Short);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:short" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:short" /> value to write.</param>
    public void WriteTag(short value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:short" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:short" /> values to write.</param>
    public void WriteListTag(string name, short[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Short, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:short" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:short" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<short> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:short" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:short" /> values to write.</param>
    public void WriteListTag(IEnumerable<short> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:short" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:short" /> values to write.</param>
    public void WriteListTag(short[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:int" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:int" /> value to write.</param>
    protected abstract void WriteValue(int value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:int" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:int" /> value to write.</param>
    public void WriteTag(string name, int value)
    {
      this.WriteStartTag(name, TagType.Int);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:int" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:int" /> value to write.</param>
    public void WriteTag(int value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:int" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:int" /> values to write.</param>
    public void WriteListTag(string name, int[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Int, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:int" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:int" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<int> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:int" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:int" /> values to write.</param>
    public void WriteListTag(IEnumerable<int> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:int" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:int" /> values to write.</param>
    public void WriteListTag(int[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:long" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:long" /> value to write.</param>
    protected abstract void WriteValue(long value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:long" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:long" /> value to write.</param>
    public void WriteTag(string name, long value)
    {
      this.WriteStartTag(name, TagType.Long);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:long" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:long" /> value to write.</param>
    public void WriteTag(long value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:long" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:long" /> values to write.</param>
    public void WriteListTag(string name, long[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Long, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:long" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:long" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<long> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:long" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:long" /> values to write.</param>
    public void WriteListTag(IEnumerable<long> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:long" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:long" /> values to write.</param>
    public void WriteListTag(long[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:float" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:float" /> value to write.</param>
    protected abstract void WriteValue(float value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:float" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:float" /> value to write.</param>
    public void WriteTag(string name, float value)
    {
      this.WriteStartTag(name, TagType.Float);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:float" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:float" /> value to write.</param>
    public void WriteTag(float value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:float" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:float" /> values to write.</param>
    public void WriteListTag(string name, float[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Float, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:float" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:float" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<float> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:float" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:float" /> values to write.</param>
    public void WriteListTag(IEnumerable<float> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:float" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:float" /> values to write.</param>
    public void WriteListTag(float[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:double" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:double" /> value to write.</param>
    protected abstract void WriteValue(double value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:double" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:double" /> value to write.</param>
    public void WriteTag(string name, double value)
    {
      this.WriteStartTag(name, TagType.Double);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:double" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:double" /> value to write.</param>
    public void WriteTag(double value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:double" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:double" /> values to write.</param>
    public void WriteListTag(string name, double[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Double, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:double" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:double" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<double> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:double" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:double" /> values to write.</param>
    public void WriteListTag(IEnumerable<double> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:double" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:double" /> values to write.</param>
    public void WriteListTag(double[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:byte[]" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:byte[]" /> value to write.</param>
    protected abstract void WriteValue(byte[] value);


    public abstract void WriteArrayValue(byte value);

    /// <summary>
    /// Writes a tag entry for a <see cref="T:byte[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:byte[]" /> value to write.</param>
    public void WriteTag(string name, byte[] value)
    {
      this.WriteStartTag(name, TagType.ByteArray);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:byte[]" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:byte[]" /> value to write.</param>
    public void WriteTag(byte[] value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:byte[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:byte[]" /> values to write.</param>
    public void WriteListTag(string name, byte[][] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.ByteArray, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:byte[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:byte[]" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<byte[]> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:byte[]" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:byte[]" /> values to write.</param>
    public void WriteListTag(IEnumerable<byte[]> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:byte[]" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:byte[]" /> values to write.</param>
    public void WriteListTag(byte[][] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:string" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:string" /> value to write.</param>
    protected abstract void WriteValue(string value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:string" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:string" /> value to write.</param>
    public void WriteTag(string name, string value)
    {
      this.WriteStartTag(name, TagType.String);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:string" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:string" /> value to write.</param>
    public void WriteTag(string value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:string" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:string" /> values to write.</param>
    public void WriteListTag(string name, string[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.String, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:string" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:string" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<string> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:string" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:string" /> values to write.</param>
    public void WriteListTag(IEnumerable<string> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:string" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:string" /> values to write.</param>
    public void WriteListTag(string[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:TagCollection" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:TagCollection" /> value to write.</param>
    protected abstract void WriteValue(TagCollection value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:TagCollection" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:TagCollection" /> value to write.</param>
    public void WriteTag(string name, TagCollection value)
    {
      this.WriteStartTag(name, TagType.List);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:TagCollection" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:TagCollection" /> value to write.</param>
    public void WriteTag(TagCollection value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:TagCollection" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:TagCollection" /> values to write.</param>
    public void WriteListTag(string name, TagCollection[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.List, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:TagCollection" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:TagCollection" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<TagCollection> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:TagCollection" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:TagCollection" /> values to write.</param>
    public void WriteListTag(IEnumerable<TagCollection> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:TagCollection" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:TagCollection" /> values to write.</param>
    public void WriteListTag(TagCollection[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:TagDictionary" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:TagDictionary" /> value to write.</param>
    protected abstract void WriteValue(TagDictionary value);


    /// <summary>
    /// Writes a tag entry for a <see cref="T:TagDictionary" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:TagDictionary" /> value to write.</param>
    public void WriteTag(string name, TagDictionary value)
    {
      this.WriteStartTag(name, TagType.Compound);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:TagDictionary" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:TagDictionary" /> value to write.</param>
    public void WriteTag(TagDictionary value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:TagDictionary" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:TagDictionary" /> values to write.</param>
    public void WriteListTag(string name, TagDictionary[] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.Compound, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:TagDictionary" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:TagDictionary" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<TagDictionary> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:TagDictionary" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:TagDictionary" /> values to write.</param>
    public void WriteListTag(IEnumerable<TagDictionary> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:TagDictionary" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:TagDictionary" /> values to write.</param>
    public void WriteListTag(TagDictionary[] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:int[]" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:int[]" /> value to write.</param>
    protected abstract void WriteValue(int[] value);


    public abstract void WriteArrayValue(int value);

    /// <summary>
    /// Writes a tag entry for a <see cref="T:int[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:int[]" /> value to write.</param>
    public void WriteTag(string name, int[] value)
    {
      this.WriteStartTag(name, TagType.IntArray);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:int[]" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:int[]" /> value to write.</param>
    public void WriteTag(int[] value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:int[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:int[]" /> values to write.</param>
    public void WriteListTag(string name, int[][] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.IntArray, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:int[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:int[]" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<int[]> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:int[]" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:int[]" /> values to write.</param>
    public void WriteListTag(IEnumerable<int[]> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:int[]" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:int[]" /> values to write.</param>
    public void WriteListTag(int[][] values)
    {
      this.WriteListTag(string.Empty, values);
    }

    /// <summary>
    /// Writes a <see cref="T:long[]" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:long[]" /> value to write.</param>
    protected abstract void WriteValue(long[] value);


    public abstract void WriteArrayValue(long value);

    /// <summary>
    /// Writes a tag entry for a <see cref="T:long[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="value">The <see cref="T:long[]" /> value to write.</param>
    public void WriteTag(string name, long[] value)
    {
      this.WriteStartTag(name, TagType.LongArray);
      this.WriteValue(value);
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:long[]" /> value.
    /// </summary>
    /// <param name="value">The <see cref="T:long[]" /> value to write.</param>
    public void WriteTag(long[] value)
    {
      this.WriteTag(string.Empty, value);
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:long[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:long[]" /> values to write.</param>
    public void WriteListTag(string name, long[][] values)
    {
      int length;

      length = values.Length;

      this.WriteStartTag(name, TagType.List, TagType.LongArray, length);
      for (int i = 0; i < length; i++)
      {
        this.WriteTag(values[i]);
      }
      this.WriteEndTag();
    }

    /// <summary>
    /// Writes a tag entry for a <see cref="T:long[]" /> value with the specified name.
    /// </summary>
    /// <param name="name">The name of the tag entry to write.</param>
    /// <param name="values">The <see cref="T:long[]" /> values to write.</param>
    public void WriteListTag(string name, IEnumerable<long[]> values)
    {
      this.WriteListTag(name, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:long[]" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:long[]" /> values to write.</param>
    public void WriteListTag(IEnumerable<long[]> values)
    {
      this.WriteListTag(string.Empty, values.ToArray());
    }

    /// <summary>
    /// Writes an unnamed tag entry for a <see cref="T:long[]" /> value.
    /// </summary>
    /// <param name="values">The <see cref="T:long[]" /> values to write.</param>
    public void WriteListTag(long[][] values)
    {
      this.WriteListTag(string.Empty, values);
    }


    /// <summary>
    /// Writes a tag value.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the type of the tag is invalid.</exception>
    /// <param name="tag">The <see cref="Tag"/> to write.</param>
    public void WriteValue(Tag tag)
    {
      switch (tag.Type)
      {
        case TagType.Byte:
          this.WriteValue(((TagByte)tag).Value);
          break;

        case TagType.Short:
          this.WriteValue(((TagShort)tag).Value);
          break;

        case TagType.Int:
          this.WriteValue(((TagInt)tag).Value);
          break;

        case TagType.Long:
          this.WriteValue(((TagLong)tag).Value);
          break;

        case TagType.Float:
          this.WriteValue(((TagFloat)tag).Value);
          break;

        case TagType.Double:
          this.WriteValue(((TagDouble)tag).Value);
          break;

        case TagType.ByteArray:
          this.WriteValue(((TagByteArray)tag).Value);
          break;

        case TagType.String:
          this.WriteValue(((TagString)tag).Value);
          break;

        case TagType.List:
          this.WriteValue(((TagList)tag).Value);
          break;

        case TagType.Compound:
          this.WriteValue(((TagCompound)tag).Value);
          break;

        case TagType.IntArray:
          this.WriteValue(((TagIntArray)tag).Value);
          break;

        case TagType.LongArray:
          this.WriteValue(((TagLongArray)tag).Value);
          break;


        default:
          throw new ArgumentException("Unrecognized or unsupported tag type.", nameof(tag));
      }
    }
  }
}

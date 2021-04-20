// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/primavara.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Server.Protos {
  public static partial class Primavara
  {
    static readonly string __ServiceName = "Primavara";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Server.Protos.UserInfoPrimavara> __Marshaller_UserInfoPrimavara = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Server.Protos.UserInfoPrimavara.Parser));
    static readonly grpc::Marshaller<global::Server.Protos.ZodiePrimavara> __Marshaller_ZodiePrimavara = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Server.Protos.ZodiePrimavara.Parser));

    static readonly grpc::Method<global::Server.Protos.UserInfoPrimavara, global::Server.Protos.ZodiePrimavara> __Method_SendBack = new grpc::Method<global::Server.Protos.UserInfoPrimavara, global::Server.Protos.ZodiePrimavara>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendBack",
        __Marshaller_UserInfoPrimavara,
        __Marshaller_ZodiePrimavara);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Server.Protos.PrimavaraReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Primavara</summary>
    [grpc::BindServiceMethod(typeof(Primavara), "BindService")]
    public abstract partial class PrimavaraBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Server.Protos.ZodiePrimavara> SendBack(global::Server.Protos.UserInfoPrimavara request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PrimavaraBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendBack, serviceImpl.SendBack).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PrimavaraBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendBack, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Server.Protos.UserInfoPrimavara, global::Server.Protos.ZodiePrimavara>(serviceImpl.SendBack));
    }

  }
}
#endregion
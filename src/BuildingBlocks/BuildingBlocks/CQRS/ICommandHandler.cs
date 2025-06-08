namespace BuildingBlocks.CQRS;
using MediatR;

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand,Unit>
 where TCommand:ICommand<Unit>
{
}



public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
   where TCommand : ICommand<TResponse>
   where TResponse : notnull
{
}
// This interface defines a command handler that processes commands in a CQRS architecture.
// It extends the MediatR IRequestHandler interface, which allows it to handle commands that implement the IRequest interface.
// The generic type parameter TCommand represents the command type that the handler will process.
// The constraints ensure that TCommand is not null and implements the IRequest interface, which is a requirement for MediatR handlers.
// This allows the command handler to be used with MediatR's dependency injection and request handling mechanisms.
// The ICommandHandler interface is typically implemented by classes that contain the logic to execute a specific command,
// such as creating, updating, or deleting resources in an application.
// Example usage:
// public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
// {
//     public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
//     {
//         // Logic to create a user
//     }
// }
// This interface is part of the BuildingBlocks.CQRS namespace, which provides a foundation for implementing the Command Query Responsibility Segregation (CQRS) pattern in applications.
// It is commonly used in applications that follow the CQRS pattern to separate command handling from query handling,
// allowing for better scalability, maintainability, and testability of the codebase.
// The ICommandHandler interface is a key component in the CQRS architecture, enabling developers to define how commands are processed
// and ensuring that the command handling logic is decoupled from other parts of the application.
// This interface is typically used in conjunction with other CQRS components, such as command objects, command validators, and command dispatchers,
// to create a complete command handling pipeline.
// By using this interface, developers can create command handlers that are easy to test and maintain,
// as they can focus on the specific logic required to handle each command without worrying about the underlying infrastructure.
// The ICommandHandler interface is a crucial part of the CQRS pattern, promoting a clean separation of concerns
// and enabling developers to build robust and scalable applications that adhere to modern software design principles.
// This interface is part of the BuildingBlocks.CQRS namespace, which provides a foundation for implementing the Command Query Responsibility Segregation (CQRS) pattern in applications.
// It is commonly used in applications that follow the CQRS pattern to separate command handling from query handling,                                   
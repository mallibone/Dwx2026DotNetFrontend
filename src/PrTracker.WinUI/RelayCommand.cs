using System.Windows.Input;

namespace PrTracker.WinUI;

/// <summary>
/// Minimal <see cref="ICommand"/> implementation so the view model has no
/// dependency on a MVVM toolkit. Call <see cref="RaiseCanExecuteChanged"/>
/// to re-query <see cref="CanExecute"/>.
/// </summary>
public sealed class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter) => _execute();

    public void RaiseCanExecuteChanged() =>
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}

namespace Wu.Wpf.ViewModels.DesignViewModels;

public class QuestionDesignViewModel : QuestionViewModel
{
    private static QuestionDesignViewModel _Instance = new();
    public static QuestionDesignViewModel Instance => _Instance ??= new();
    public QuestionDesignViewModel()
    {

    }
}

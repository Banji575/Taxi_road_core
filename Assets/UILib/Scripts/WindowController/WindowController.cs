using UnityEngine;

public class WindowController : MonoBehaviour
{
    // Поля
    [SerializeField]
    private Animator windowAnimator; // Ссылка на аниматор

    [SerializeField]
    private string openTrigger = "Open"; // Имя триггера для открытия

    [SerializeField]
    private string closeTrigger = "Close"; // Имя триггера для закрытия

    private bool isClosing = false; // Флаг для отслеживания состояния закрытия

    // Метод для открытия окна
    public void WindowControllerOpen()
    {
        if (windowAnimator != null)
        {
            windowAnimator.SetTrigger(openTrigger); // Устанавливаем триггер открытия
        }
        else
        {
            Debug.LogWarning("Animator не установлен на " + gameObject.name);
        }
    }

    // Метод для закрытия окна с анимацией
    public void WindowControllerClose()
    {
        if (windowAnimator != null && !isClosing)
        {
            isClosing = true; // Устанавливаем флаг, что окно закрывается
            windowAnimator.SetTrigger(closeTrigger); // Устанавливаем триггер закрытия

            // Запускаем корутину для ожидания завершения анимации
            StartCoroutine(WaitForCloseAnimation());
        }
        else
        {
            Debug.LogWarning("Animator не установлен или окно уже закрывается на " + gameObject.name);
        }
    }

    // Метод для быстрого закрытия окна без анимации
    public void WindowControllerFastClose()
    {
        Destroy(gameObject); // Немедленно уничтожаем объект
    }

    // Корутин для ожидания завершения анимации закрытия
    private System.Collections.IEnumerator WaitForCloseAnimation()
    {
        // Ожидаем окончания текущей анимации
        yield return new WaitForEndOfFrame();

        // Получаем информацию о текущем состоянии анимации
        var animatorStateInfo = windowAnimator.GetCurrentAnimatorStateInfo(0);
        
        // Ожидаем продолжительность анимации закрытия
        yield return new WaitForSeconds(animatorStateInfo.length);
        
        // Уничтожаем объект после завершения анимации
        Destroy(gameObject);
    }
}

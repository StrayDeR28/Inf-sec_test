using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string firstName;
    public string middleName;
    public string lastName;

    public string email;
    public string nickName;

    //титул
    //биты
    //прогресс по кейсам
    //пройденные сцены
    //подсказки
    ErrorCode error;
    /*
        код ошибки
            0 - нет ошибки
            1 - нет пользователя
            2 - неверный пароль
            3 - пользователь занят           
            4 - ник занят
    */
}

enum ErrorCode {none, loginError, signupError}
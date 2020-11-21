public static class CommonGameData
{
    private static float _playerScore = 0f;
    private static float _maxPlayerScore = 0f;
    private static float _dangerCarsSpeed = 0f;
    private static float _staticObjectsSpeed = 0f;

    public static float PlayerScore { get => _playerScore; set => _playerScore = value; }
    public static float MaxPlayerScore { get => _maxPlayerScore; set => _maxPlayerScore = value; }
    public static float DangerCarsSpeed { get => _dangerCarsSpeed; set => _dangerCarsSpeed = value; }
    public static float StaticObjectsSpeed { get => _staticObjectsSpeed; set => _staticObjectsSpeed = value; }

    public static void ResetValues()
    {
        _playerScore = 0;
        _dangerCarsSpeed = 4f;
        _staticObjectsSpeed = 4f;
    }
}

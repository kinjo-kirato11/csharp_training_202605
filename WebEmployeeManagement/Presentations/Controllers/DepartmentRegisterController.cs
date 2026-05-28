using Microsoft.AspNetCore.Mvc;
using WebEmployeeManagement.Applications.Services;
using WebEmployeeManagement.Presentations.ViewModels;

namespace WebEmployeeManagement.Presentations.Controllers;
/// <summary>
/// 従業員登録コントローラ
/// </summary>
[Route("DepartmentRegister")]
public class DepartmentRegisterController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<DepartmentRegisterController> _logger;
    /// <summary>
    /// 従業員登録サービスインターフェイス
    /// </summary>
    private readonly IDepartmentRegisterService _departmentRegisterService;
    /// <summary>
    /// 従業員登録ViewModelをEmployeeに変換するアダプター
    /// </summary>
    private readonly DepatmentRegisterViewModelAdapter _adapter;
              
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<DepartmentRegisterViewModel> _deptDataStore;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="departmentRegisterService">従業員登録サービスインターフェイス</param>
    /// <param name="departmentRegisterViewModelAdapter">従業員登録ViewModelをEmployeeに変換するアダプター</param>
    /// <param name="deptDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    public DepartmentRegisterController(
        ILogger<DepartmentRegisterController> logger,
        IDepartmentRegisterService departmentRegisterService,
        DepatmentRegisterViewModelAdapter departmentRegisterViewModelAdapter,
        TempDataStore<DepartmentRegisterViewModel> deptDataStore)
    {
        _logger = logger;
        _departmentRegisterService = departmentRegisterService;
        _adapter = departmentRegisterViewModelAdapter;
        _deptDataStore = deptDataStore;
    }

    /// <summary>
    /// 部署登録(入力)画面表示 アクションメソッド
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public IActionResult Enter()
    {
        DepartmentRegisterViewModel? viewModel = null;
        // [戻る]ボタンへの対応
        // TempDataからEmployeeRegisterViewModelを取得する
        viewModel = _deptDataStore.Load(this);
        if (viewModel == null)
        {
            // 部署登録ViewModelを生成する
            viewModel = new DepartmentRegisterViewModel();
        }

        // viewModelをviewに渡して画面表示する
        return View(viewModel);
    }

    /// <summary>
    /// 入力画面の[完了]ボタンクリックアクションメソッド
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPost("Confirm")]
    public IActionResult Confirm(DepartmentRegisterViewModel viewModel)
    {
        // バリデーションチェック
        if (!ModelState.IsValid) // バリデーションエラーあり
        {

            // 入力画面の表示
            return View("Enter", viewModel);
        }
        // 選択された部署のIdで部署データを取得する
       // var department = _departmentRegisterService.GetById(viewModel.DeptId ?? 0);
       // _logger.LogInformation($"部署Id:{viewModel.DeptId ?? 0}の部署を取得する");
        // ViewModelに部署名を設定する
        //viewModel.DeptName = department.Name;
        // 確認画面を表示する
        return View(viewModel);
    }

    /// <summary>
    /// 確認画面の[登録]ボタンクリックアクションメソッド
    /// </summary>
    /// <param name="form"></param>
    /// <returns></returns>
    [HttpPost("Regiter")]
    public IActionResult Register(DepartmentRegisterViewModel viewModel)
    {
        _deptDataStore.Save(this, viewModel);
        // 登録処理GETアクションメソッドにリダイレクトする
        return RedirectToAction("Complete");
    }

    /// <summary>
    /// アクションメソッド:Regiter()のリダイレクト先
    /// PRGパターン
    /// </summary>
    /// <returns></returns>
    [HttpGet("Complete")]
    public IActionResult Complete()
    {
        DepartmentRegisterViewModel? viewModel = null;
        viewModel = _deptDataStore.Load(this);
        if (viewModel == null)
        {
            // データが存在しない場合、入力画面にリダイレクト
            return RedirectToAction("Enter");
        }
        var department = _adapter.Restore(viewModel!);
        // 新しい部署を登録する
        _departmentRegisterService.Register(department);
        return View(viewModel);
    }

    /// <summary>
    /// 確認画面の[戻る]ボタンクリックアクションメソッド
    /// </summary>
    /// <returns></returns> 
    [HttpPost("Back")]
    public IActionResult Back(DepartmentRegisterViewModel viewModel)
    {
        _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
        _deptDataStore.Save(this, viewModel);
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }



}
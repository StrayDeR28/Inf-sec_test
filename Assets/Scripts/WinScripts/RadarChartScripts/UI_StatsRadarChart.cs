using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatsRadarChart : MonoBehaviour {

    [SerializeField] private Material radarMaterial;
    [SerializeField] private Texture2D radarTexture2D;

    private Stats stats;
    private CanvasRenderer radarMeshCanvasRenderer;

    private void Awake() {
        radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
    }

    public void SetStats(Stats stats) {
        this.stats = stats;
        stats.OnStatsChanged += Stats_OnStatsChanged;
        UpdateStatsVisual();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e) {
        UpdateStatsVisual();
    }

    private void UpdateStatsVisual() {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[9];
        Vector2[] uv = new Vector2[9];
        int[] triangles = new int[3 * 8];

        float angleIncrement = 360f / 8;
        float radarChartSize = 50f;

        Vector3 ZerokottoVertex     = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Zerokotto);
        int ZerokottoVertexIndex    = 1;
        Vector3 PitambaVertex       = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Pitamba);
        int PitambaVertexIndex      = 2;
        Vector3 AndroididzuVertex   = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Androididzu);
        int AndroididzuVertexIndex  = 3;
        Vector3 ReliaochokiVertex   = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Reliaochoki);
        int ReliaochokiVertexIndex  = 4;
        Vector3 ChatabottoVertex    = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Chatabotto);
        int ChatabottoVertexIndex   = 5;
        Vector3 IgrahagiVertex      = Quaternion.Euler(0, 0, -angleIncrement * 5) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Igrahagi);
        int IgrahagiVertexIndex     = 6;
        Vector3 JavascriptuVertex   = Quaternion.Euler(0, 0, -angleIncrement * 6) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Javascriptu);
        int JavascriptuVertexIndex  = 7;
        Vector3 NapitoneVertex      = Quaternion.Euler(0, 0, -angleIncrement * 7) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Napitone);
        int NapitoneVertexIndex     = 8;

        vertices[0]                      = Vector3.zero;
        vertices[ZerokottoVertexIndex]   = ZerokottoVertex;
        vertices[PitambaVertexIndex]     = PitambaVertex;
        vertices[AndroididzuVertexIndex] = AndroididzuVertex;
        vertices[ReliaochokiVertexIndex] = ReliaochokiVertex;
        vertices[ChatabottoVertexIndex]  = ChatabottoVertex;
        vertices[IgrahagiVertexIndex]    = IgrahagiVertex;
        vertices[JavascriptuVertexIndex] = JavascriptuVertex;
        vertices[NapitoneVertexIndex]    = NapitoneVertex;

        uv[0]                      = Vector2.zero;
        uv[ZerokottoVertexIndex]   = Vector2.one;
        uv[PitambaVertexIndex]     = Vector2.one;
        uv[AndroididzuVertexIndex] = Vector2.one;
        uv[ReliaochokiVertexIndex] = Vector2.one;
        uv[ChatabottoVertexIndex]  = Vector2.one;
        uv[IgrahagiVertexIndex]    = Vector2.one;
        uv[JavascriptuVertexIndex] = Vector2.one;
        uv[NapitoneVertexIndex]    = Vector2.one;

        triangles[0] = 0;
        triangles[1] = ZerokottoVertexIndex;
        triangles[2] = PitambaVertexIndex;

        triangles[3] = 0;
        triangles[4] = PitambaVertexIndex;
        triangles[5] = AndroididzuVertexIndex;

        triangles[6] = 0;
        triangles[7] = AndroididzuVertexIndex;
        triangles[8] = ReliaochokiVertexIndex;

        triangles[9]  = 0;
        triangles[10] = ReliaochokiVertexIndex;
        triangles[11] = ChatabottoVertexIndex;

        triangles[12] = 0;
        triangles[13] = ChatabottoVertexIndex;
        triangles[14] = IgrahagiVertexIndex;

        triangles[15] = 0;
        triangles[16] = IgrahagiVertexIndex;
        triangles[17] = JavascriptuVertexIndex;

        triangles[18] = 0;
        triangles[19] = JavascriptuVertexIndex;
        triangles[20] = NapitoneVertexIndex;

        triangles[21] = 0;
        triangles[22] = NapitoneVertexIndex;
        triangles[23] = ZerokottoVertexIndex;


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, radarTexture2D);
    }

}

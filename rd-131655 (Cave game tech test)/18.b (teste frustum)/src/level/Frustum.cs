namespace RubyDung;

public class Frustum {
    // Matriz que representa os 6 planos do frustum (visão 3D da câmera)
    public float[][] m_Frustum = new float[6][];

    // Instância singleton do frustum
    private static Frustum frustum = new Frustum();

    private Frustum() {
        // Inicializa os planos do frustum
        for (int i = 0; i < 6; i++)
        {
            m_Frustum[i] = new float[4];
        }
    }

    // Obtém a instância singleton do frustum
    public static Frustum GetFrustum() {
        frustum.CalculateFrustum();
        return frustum;
    }

    // Calcula os planos do frustum baseado nas matrizes atuais
    private void CalculateFrustum() {
        // Obtém as matrizes de projeção e modelo do OpenGL
        GL.GetFloat(GetPName.ProjectionMatrix, _proj);
        GL.GetFloat(GetPName.ModelviewMatrix, _modl);
        
        // Copia os dados para as matrizes auxiliares
        Array.Copy(_proj, proj, 16);
        Array.Copy(_modl, modl, 16);
        
        // Calcula a matriz de recorte combinando projeção e modelo
        clip[0] = modl[0] * proj[0] + modl[1] * proj[4] + modl[2] * proj[8] + modl[3] * proj[12];
        clip[1] = modl[0] * proj[1] + modl[1] * proj[5] + modl[2] * proj[9] + modl[3] * proj[13];
        clip[2] = modl[0] * proj[2] + modl[1] * proj[6] + modl[2] * proj[10] + modl[3] * proj[14];
        clip[3] = modl[0] * proj[3] + modl[1] * proj[7] + modl[2] * proj[11] + modl[3] * proj[15];
        
        clip[4] = modl[4] * proj[0] + modl[5] * proj[4] + modl[6] * proj[8] + modl[7] * proj[12];
        clip[5] = modl[4] * proj[1] + modl[5] * proj[5] + modl[6] * proj[9] + modl[7] * proj[13];
        clip[6] = modl[4] * proj[2] + modl[5] * proj[6] + modl[6] * proj[10] + modl[7] * proj[14];
        clip[7] = modl[4] * proj[3] + modl[5] * proj[7] + modl[6] * proj[11] + modl[7] * proj[15];
        
        clip[8] = modl[8] * proj[0] + modl[9] * proj[4] + modl[10] * proj[8] + modl[11] * proj[12];
        clip[9] = modl[8] * proj[1] + modl[9] * proj[5] + modl[10] * proj[9] + modl[11] * proj[13];
        clip[10] = modl[8] * proj[2] + modl[9] * proj[6] + modl[10] * proj[10] + modl[11] * proj[14];
        clip[11] = modl[8] * proj[3] + modl[9] * proj[7] + modl[10] * proj[11] + modl[11] * proj[15];
        
        clip[12] = modl[12] * proj[0] + modl[13] * proj[4] + modl[14] * proj[8] + modl[15] * proj[12];
        clip[13] = modl[12] * proj[1] + modl[13] * proj[5] + modl[14] * proj[9] + modl[15] * proj[13];
        clip[14] = modl[12] * proj[2] + modl[13] * proj[6] + modl[14] * proj[10] + modl[15] * proj[14];
        clip[15] = modl[12] * proj[3] + modl[13] * proj[7] + modl[14] * proj[11] + modl[15] * proj[15];
        
        // Extrai os 6 planos do frustum da matriz de recorte
        // Plano direito
        m_Frustum[0][0] = clip[3] - clip[0];
        m_Frustum[0][1] = clip[7] - clip[4];
        m_Frustum[0][2] = clip[11] - clip[8];
        m_Frustum[0][3] = clip[15] - clip[12];
        NormalizePlane(m_Frustum, 0);
        
        // Plano esquerdo
        m_Frustum[1][0] = clip[3] + clip[0];
        m_Frustum[1][1] = clip[7] + clip[4];
        m_Frustum[1][2] = clip[11] + clip[8];
        m_Frustum[1][3] = clip[15] + clip[12];
        NormalizePlane(m_Frustum, 1);
        
        // Plano inferior
        m_Frustum[2][0] = clip[3] + clip[1];
        m_Frustum[2][1] = clip[7] + clip[5];
        m_Frustum[2][2] = clip[11] + clip[9];
        m_Frustum[2][3] = clip[15] + clip[13];
        NormalizePlane(m_Frustum, 2);
        
        // Plano superior
        m_Frustum[3][0] = clip[3] - clip[1];
        m_Frustum[3][1] = clip[7] - clip[5];
        m_Frustum[3][2] = clip[11] - clip[9];
        m_Frustum[3][3] = clip[15] - clip[13];
        NormalizePlane(m_Frustum, 3);
        
        // Plano traseiro (far)
        m_Frustum[4][0] = clip[3] - clip[2];
        m_Frustum[4][1] = clip[7] - clip[6];
        m_Frustum[4][2] = clip[11] - clip[10];
        m_Frustum[4][3] = clip[15] - clip[14];
        NormalizePlane(m_Frustum, 4);
        
        // Plano frontal (near)
        m_Frustum[5][0] = clip[3] + clip[2];
        m_Frustum[5][1] = clip[7] + clip[6];
        m_Frustum[5][2] = clip[11] + clip[10];
        m_Frustum[5][3] = clip[15] + clip[14];
        NormalizePlane(m_Frustum, 5);
    }

    // Verifica se um cubo está parcialmente dentro do frustum
    public bool CubeInFrustum(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        for (int i = 0; i < 6; i++)
        {
            if (!(m_Frustum[i][0] * x1 + m_Frustum[i][1] * y1 + m_Frustum[i][2] * z1 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x2 + m_Frustum[i][1] * y1 + m_Frustum[i][2] * z1 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x1 + m_Frustum[i][1] * y2 + m_Frustum[i][2] * z1 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x2 + m_Frustum[i][1] * y2 + m_Frustum[i][2] * z1 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x1 + m_Frustum[i][1] * y1 + m_Frustum[i][2] * z2 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x2 + m_Frustum[i][1] * y1 + m_Frustum[i][2] * z2 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x1 + m_Frustum[i][1] * y2 + m_Frustum[i][2] * z2 + m_Frustum[i][3] > 0.0f) &&
                !(m_Frustum[i][0] * x2 + m_Frustum[i][1] * y2 + m_Frustum[i][2] * z2 + m_Frustum[i][3] > 0.0f))
            {
                return false;
            }
        }

        return true;
    }

    // Verifica se um AABB (Axis-Aligned Bounding Box) está dentro do frustum
    public bool CubeInFrustum(AABB aabb) {
        return CubeInFrustum(aabb.x0, aabb.y0, aabb.z0, aabb.x1, aabb.y1, aabb.z1);
    }
}

namespace RubyDung;

public class AABB {
    private Level level;
    private Player player;

    public float x0;
    public float y0;
    public float z0;
    public float x1;
    public float y1;
    public float z1;

    private AABB playerAABB;

    private float w_player = 0.3f;
    private float h_player = 0.9f;

    public AABB(Level level, Player player) {
        this.level = level;
        this.player = player;
    }

    public AABB(float x0, float y0, float z0, float x1, float y1, float z1) {
        this.x0 = x0;
        this.y0 = y0;
        this.z0 = z0;

        this.x1 = x1;
        this.y1 = y1;
        this.z1 = z1;
    }

    public void OnUpdateFrame() {
        SetPos_Player();
        Move_Player();
    }

    public float ClipXCollide(AABB c) {
        if(c.x1 >= x0 && c.x0 <= x1) {
            if(c.y1 >= y0 && c.y0 <= y1) {
                if(c.z1 >= z0 && c.z0 <= z1) {
                    if(c.x0 < x0 && c.x1 > x0) {
                        return x0 - w_player;
                    }
                    if(c.x0 < x1 && c.x1 > x1) {
                        return x1 + w_player;
                    }
                }
            }
        }

        return player.position.X;
    }
    
    public float ClipYCollide(AABB c) {
        if(c.x1 >= x0 && c.x0 <= x1) {
            if(c.y1 >= y0 && c.y0 <= y1) {
                if(c.z1 >= z0 && c.z0 <= z1) {
                    if(c.y0 < y0 && c.y1 > y0) {
                        return y0 - h_player;
                    }
                    if(c.y0 < y1 && c.y1 > y1) {
                        return y1 + h_player;
                    }
                }
            }
        }

        return player.position.Y;
    }
    
    public float ClipZCollide(AABB c) {
        if(c.x1 >= x0 && c.x0 <= x1) {
            if(c.y1 >= y0 && c.y0 <= y1) {
                if(c.z1 >= z0 && c.z0 <= z1) {
                    if(c.z0 < z0 && c.z1 > z0) {
                        return z0 - w_player;
                    }
                    if(c.z0 < z1 && c.z1 > z1) {
                        return z1 + w_player;
                    }
                }
            }
        }

        return player.position.Z;
    }

    private void SetPos_Player() {
        float x = player.position.X;
        float y = player.position.Y;
        float z = player.position.Z;

        float w = 0.3f;
        float h = 0.9f;

        playerAABB = new AABB(x - w, y - h, z - w, x + w, y + h, z + w);
    }

    private void Move_Player() {
        List<AABB> levelAABB = GetCubes_Level(playerAABB);

        for(int i = 0; i < levelAABB.Count; i++) {
            AABB blockAABB = levelAABB[i];

            float overlapX = Math.Min(playerAABB.x1 - blockAABB.x0, blockAABB.x1 - playerAABB.x0);
            float overlapY = Math.Min(playerAABB.y1 - blockAABB.y0, blockAABB.y1 - playerAABB.y0);
            float overlapZ = Math.Min(playerAABB.z1 - blockAABB.z0, blockAABB.z1 - playerAABB.z0);

            if(overlapX < overlapY && overlapX < overlapZ) {
                player.position.X = blockAABB.ClipXCollide(playerAABB);
            }
            if(overlapY < overlapX && overlapY < overlapZ) {
                player.position.Y = blockAABB.ClipYCollide(playerAABB);
            }
            if(overlapZ < overlapX && overlapZ < overlapY) {
                player.position.Z = blockAABB.ClipZCollide(playerAABB);
            }
        }
    }

    private List<AABB> GetCubes_Level(AABB aabb) {
        List<AABB> AABBs = new List<AABB>();

        int x0 = (int)aabb.x0;
        int y0 = (int)aabb.y0;
        int z0 = (int)aabb.z0;

        int x1 = (int)aabb.x1;
        int y1 = (int)aabb.y1;
        int z1 = (int)aabb.z1;

        for(int x = x0; x <= x1; x++) {
            for(int y = y0; y <= y1; y++) {
                for(int z = z0; z <= z1; z++) {
                    if(level.IsSolidTile(x, y, z)) {
                        AABBs.Add(new AABB(x, y, z, x + 1, y + 1, z + 1));
                    }
                }
            }
        }

        return AABBs;
    }
}
using UnityEngine;

namespace Mono
{
    public class DrawGizmo : MonoBehaviour
    {
        public float circleRadius = 0.1f;
        public float circleDuration = 2f;
        private bool shouldDrawCircle = false;
        private Vector3 circlePosition;
        private float timer = 0f;

        void Update()
        {
            // 检测鼠标左键是否被按下
            if (Input.GetMouseButtonDown(0))
            {
                // 获取鼠标在屏幕上的位置
                Vector3 mousePosition = Input.mousePosition;
                // 设置 Z 轴为相机到 XY 平面的距离
                mousePosition.z = -Camera.main.transform.position.z;
                // 将屏幕坐标转换为世界坐标
                circlePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                // 标记需要绘制圆形
                shouldDrawCircle = true;
                // 重置计时器
                timer = 0f;
            }

            // 如果需要绘制圆形，更新计时器
            if (shouldDrawCircle)
            {
                timer += Time.deltaTime;
                // 当计时器超过 2 秒时，停止绘制圆形
                if (timer >= circleDuration)
                {
                    shouldDrawCircle = false;
                }
            }
        }

        void OnDrawGizmos()
        {
            // 如果需要绘制圆形
            if (shouldDrawCircle)
            {
                // 设置 Gizmos 的颜色
                Gizmos.color = Color.red;
                // 在指定位置绘制圆形
                Gizmos.DrawWireSphere(circlePosition, circleRadius);
            }
        }
    }
}